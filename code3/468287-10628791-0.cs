    using System;
    namespace Test
    {
        public class Program
        {
            private static void Main()
            {
                var foo = new Foo();
                Console.WriteLine(foo.Name);
                Console.ReadKey();
            }
        }
        public class Foo : Bah
        {
            public Foo() : base("Foo!") { }
            public override string Name
            {
                get { return _name + "123"; }
                set { _name = value; }
            }
        }
        public class Bah
        {
            protected string _name;
            public Bah(string name)
            {
                Name = name; // << -- No Exception here (or anywhere!)
            }
            public virtual string Name
            {
                get { return _name; }
                set { _name = value; }
            }
        }
    }
