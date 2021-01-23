    public class Class1
    {
        public Class1()
        {
            Foo();
        }
        public virtual void Foo()
        {
        }
    }
    public class Class2 : Class1
    {
        protected int i = 5;
        protected int j;
        public Class2()
        {
            j = 5;
        }
        public override void Foo()
        {
            Console.WriteLine("i:" + i);
            Console.WriteLine("j:" + j);
        }
    }
