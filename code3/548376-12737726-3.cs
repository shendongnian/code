    public interface IData
    {
        string PilotName { get; }
        string Ship { get; }
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        Decimal Rate { get; }
    }
