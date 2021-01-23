    public interface IDevice
    {
        double Measure();
        string ConcurrencyGroupName { get; }
    }
