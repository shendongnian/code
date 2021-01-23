    public interface IBar
    {
        void Foo(int i);
    }
    
    public class Bar : IBar
    {
        public void Foo<T>(T i)
        {
        }
    }
