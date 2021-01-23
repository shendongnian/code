    public enum SteerState
    {
        RotationOn,
        Collision,
        Break,
        BreakTime,
        RotationOnBreak,
        RangeFromSpawn,
        Speed
    }
    
    public IdleSteering(IDictionary<SteerState, SteerSettings> settings)
    {
        ...
    }
