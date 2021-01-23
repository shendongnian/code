    enum ThingStatus { Accepted, Denied, Pending };
    public interface Thing
    {
        ThingStatus status { get; }
        etc...
    }
