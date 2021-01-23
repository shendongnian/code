    public abstract class Foo
    {
        protected Foo(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    
        public abstract void doStuff();
    }
    public class Bar : Foo
    {
        public Bar(int a, int b, int c) : base(a, b, c)
        {
        }
    
        public override void doStuff()
        {
            //does stuff
        }
    }
    
    
    public class BarY : Foo
    {
        public BarY(int a, int b, int c) : base(a, b, c)
        {
        }
    
        public override void doStuff()
        {
            //does stuff
        }
    }
