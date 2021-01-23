    abstract class A<T>
    {
        public abstract T f();
    }
    
    class B<T> : A<T>
    {
        public override T f()
        {
            return default (T);
        }
    }
