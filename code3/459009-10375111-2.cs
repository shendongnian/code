    public class A
    {
        protected int x;
    
        public int X { set { x = value; }  }
    }
    public static A CreateClassA()
    {
        A x = new A();
        x.X = 5;
        return x;
    }
