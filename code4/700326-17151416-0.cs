    public enum SeriesKey
    {
        SomeKey1,
        SomeKey2,
        SomeKey3
    }
    
    public interface ISeries
    {
        SeriesKey Key { get; }
    }
