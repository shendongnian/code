    public abstract class Base<S>
    {
        public static Derived<S, T> Create<T>() 
        {
            return new ReallyDerived<S, T>(); 
        }
        class ReallyDerived<U, T> : Derived<S, T>
        {
            public ReallyDerived()
            {
            }
        }
    }
    
    public abstract class Derived<S, T> : Base<S>
    {
    }
