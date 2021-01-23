    public class A
    {
        public A()
        {
            Type c = GetType();
            if (c != typeof(A) && c != typeof(B)) throw ....;
        }
    }
