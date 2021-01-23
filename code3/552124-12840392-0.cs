    public interface ISCrollable
    {
        Control Target { get; }
        ScrollBar Bar { get; }
        double FullLength { get; }
        double VisibleLength { get; }
    }
