    public interface IParent
    {
        IEnumerable<Child> Children { get; }
    }
    public interface IParent<T> : IParent
      where T: Child
    {
        IEnumerable<T> Children { get; }
    }
