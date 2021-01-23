    using System;
    using System.Dynamic;
    
    class Program
    {
        static void Main(string[] args)
        {
            dynamic d = new ArgumentDumper();
            Console.WriteLine("First call");
            d.Foo(1, 2, 3);
            Console.WriteLine("Second call");
            d.Bar(new int[] { 1, 2, 3 });
        }
    }
    
    class ArgumentDumper : DynamicObject
    {
        public override bool TryInvokeMember
            (InvokeMemberBinder binder,
             Object[] args,
             out Object result)
        {
            result = null;
            foreach (object x in args)
            {
                Console.WriteLine(x.GetType().Name);
            }
            return true;
        }
    }
