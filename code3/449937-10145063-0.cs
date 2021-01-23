    public abstract class A<T> where T : SomeBaseClass
    {
        protected abstract void Add(T number);
    }
    public class B : A<C> {
        protected void Add(C number) { ... }
    }
