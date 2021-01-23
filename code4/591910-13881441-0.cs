    public interface IClassA
    {
        string Description { get; set; }
    }
    public class ClassA<T> : IClassA
    {
        ...
    }
    public void DoWork(IClassA source, IClassA destination)
    {
        destination.Description = source.Description;
    }
