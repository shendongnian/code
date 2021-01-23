    using System;
    using System.ComponentModel;
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
            var d = (FooAttribute)TypeDescriptor.GetAttributes(typeof(Program))[
                typeof(FooAttribute)];
            d.Bar = "world";
            WriteFooBar<Program>();
        }
        static void WriteFooBar<T>() {
            var bar = ((FooAttribute)TypeDescriptor.GetAttributes(typeof(Program))[
                typeof(FooAttribute)]).Bar;
            Console.WriteLine(bar);
        }
    }
