    public class A<T> where T:A<T>
    {
        public string X { get; private set; }
        public T SetX(string x)
        {
            X = x;
            return (T) this;
        }
    }
    public class B<T> : A<T>
        where T : B<T>
    {
        public string Y { get; private set; }
        public T SetY(string y)
        {
            Y = y;
            return (T) this;
        }
    }
    public class A : A<A>
    {
    }
    public class B : B<B>
    {
    }
