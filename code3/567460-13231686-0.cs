    using System;
    using System.Linq;
    class Foo
    {
        public Foo(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }
        public string Expensive()
        {
            Console.WriteLine(Value);
            return Value;
        }
        static void Main()
        {
            var foos = new[] {
                new Foo("abc"),
                new Foo("def")};
            Console.WriteLine("query1:");
            var query1 = (from obj in foos
                          let val = obj.Value
                          where val.StartsWith("a")
                          let result = obj.Expensive()
                          select result).ToArray();
            Console.WriteLine("query2:");
            var query2 = (from obj in foos
                          let val = obj.Value
                          let result = obj.Expensive()
                          where val.StartsWith("a")                      
                          select result).ToArray();    
        }
    }
