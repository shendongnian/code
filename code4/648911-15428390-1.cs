    class Program
    {
        static void Main(string[] args)
        {
            MyBaseClass ext1 = new Ext1();
            ext1.DoSomething();
            MyBaseClass ext2 = new Ext2();
            ext2.DoSomething();
            
            Console.ReadKey(true);
        }
    }
    class MyBaseClass
    {
        public void DoSomething()
        {
            DoSomethingBase();
        }
        protected virtual void DoSomethingBase()
        {
            Console.WriteLine("DoSomethingBase");
        }
    }
    class Ext1 : MyBaseClass
    {
        
    }
    class Ext2 : MyBaseClass
    {
        protected override void DoSomethingBase()
        {
            Console.WriteLine("Overridden DoSomethingBase");
        }
    }
