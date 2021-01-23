    public interface ICreator
    {
        IPart Create();
    }
    public interface IPart
    {
        // Part interface methods
    }
    // a sample creator/part
    public PositionPartCreator : ICreator
    {
        public IPart Create() { return new PositionPart(); }
    }
    public PositionPart : IPart
    {
        // implementation
    }
