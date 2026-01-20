using Content.Shared.Roles;
using Robust.Shared.Prototypes;

namespace Content.Server.Spawners.Components;

[RegisterComponent]
public sealed partial class SpawnPointComponent : Component, ISpawnPoint
{
    [DataField("job_id")]
    public ProtoId<JobPrototype>? Job;

    /// <summary>
    /// Just so I dont have to edit every darn map in the world just to add in Scrod Scaler
    /// This is a list of alternative jobs that can be spawned at this spawn point
    /// </summary>
    [DataField("alt_jobs")]
    public List<ProtoId<JobPrototype>> AltJobs = new();

    /// <summary>
    /// The type of spawn point
    /// </summary>
    [DataField("spawn_type"), ViewVariables(VVAccess.ReadWrite)]
    public SpawnPointType SpawnType { get; set; } = SpawnPointType.Unset;

    public override string ToString()
    {
        if (AltJobs.Count > 0)
        {
            return $"{Job} (Alts: {string.Join(", ", AltJobs)}) {SpawnType}";
        }
        return $"{Job} {SpawnType}";
    }
}

public enum SpawnPointType
{
    Unset = 0,
    LateJoin,
    Job,
    Observer,
}
