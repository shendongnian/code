    using System;
    class FooAttribute : Attribute {
        public FooAttribute(string bar) {
            Bar = bar;
        }
        public string Bar { get; set; }
    }
    [Foo("hello")]
    class Program {
        static void Main() {
            WriteFooBar<Program>();
            var d = (FooAttribute)Attribute.GetCustomAttribute(
                typeof(Program), typeof(FooAttribute));
            d.Bar = "world";
            WriteFooBar<Program>();
        }
        static void WriteFooBar<T>() {
            var bar = ((FooAttribute)Attribute.GetCustomAttribute(
                typeof(T), typeof(FooAttribute))).Bar;
            Console.WriteLine(bar);
        }
    }
