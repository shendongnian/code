    public class A
    {
        protected internal int x;
    }
    
    public class B
    {
        public static A CreateClassA()
        {
            A x = new A();
            x.x = 5;   // hurray
            return x;
        }
    }
