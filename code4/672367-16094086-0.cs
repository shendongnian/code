    public class Base<S>
    {
        public static IFoo<S, T> Create<T>()
        {
            return new Derived<T>(); //if not public, I wont get it here.
        }
    
        // Only generic in T, as we can use S from the containing class
        private class Derived<T> : Base<S>, IFoo<S, T>
        {
            public Derived()
            {
                ...
            }
        }
    }
    public interface IFoo<S, T>
    {
        // Whatever members you want
    }
