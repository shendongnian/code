    public class Parent { }
    public class Child { }
    public interface Interface
    {
        void Foo<T>() where T : Parent;
    }
    public class Implementation : Interface
    {
        public void Foo<T>() where T : Child
        {
        }
    }
