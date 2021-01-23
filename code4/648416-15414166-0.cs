    public interface IBase<out T> where T : I
    {
        IEnumerable<T> Collection { get; }
    }
    public class A : IBase<D1>
    {
        IEnumerable<D1> Collection { get; private set; }
 
        public A(IEnumerable<D1> list)
        {
            Collection = list;
        }
    }
    public class B : IBase<D2>
    {
        IEnumerable<D2> Collection { get; private set; }
 
        public B(IEnumerable<D2> list)
        {
            Collection = list;
        }
    }
