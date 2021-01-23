    using System;
    
    public class Program
    {
        public static void Main()
        {
            Foo foo = new Foo();
            Bar bar = (Bar)foo;
    
            // writes "1" (or would, if the program compiled)
            Console.WriteLine(bar);
    
            // throws compilation error: "Cannot convert type `Foo' to `Bar' via built-in conversion"
            bar = foo as Bar;
            // note: the same would happen if `foo` was type int? and `bar` was type `double?`
            //       even though double? can be converted to int?
        }
    }
    
    class Foo
    {
        public readonly int Value = 1;
    
        public static explicit operator Bar(Foo foo)
        {
            return new Bar(foo.Value.ToString());
        }
    }
    
    class Bar
    {
        public readonly string Value;
    
        public Bar(string value)
        {
            Value = value;
        }
    }
