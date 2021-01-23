    public interface ICopyable<T>
    {
        T Copy(params);
    }
    public class C : ICopyable<C> { ... }
    public class D : C, ICopyable<D> { ... }
