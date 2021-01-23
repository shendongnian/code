    public interface ISkeleton
    {
        AttachableEnumerable<IBone> Bones { get; }
    }
    
    public class AttachableEnumerable<T> : IEnumerable<T>
    {
        // implementation needed.
        void Attach(T item);
        void Detach(T item);
    }
