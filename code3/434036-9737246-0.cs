    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        delegate bool CompareFunction(Fii test, Foo item);
        class Program
        {
            static List<Foo> list = new List<Foo>() {
                new Foo() { PropertyA = 0, PropertyB = 9 },
                new Foo() { PropertyA = 1, PropertyB = 10 }
            };
            static Fii test = new Fii() { PropertyA = 1 };
            static void Main(string[] args)
            {
                Bar(list, delegate(Fii item1, Foo item2) { return item2.PropertyA < item1.PropertyA; });
                Bar(list, delegate(Fii item1, Foo item2) { return item2.PropertyB > item1.PropertyA; });
                Bar(list, delegate(Fii item1, Foo item2) { return item2.PropertyA == item1.PropertyA; });
                Console.ReadLine();
            }
            static void Bar(List<Foo> list, CompareFunction cmp)
            {
                foreach (Foo item in list)
                    if (cmp(test, item))
                        Console.WriteLine("true");
                    else
                        Console.WriteLine("false");
            }
        }
        class Foo
        {
            public int PropertyA { get; set; }
            public int PropertyB { get; set; }
        }
        class Fii
        {
            public int PropertyA { get; set; }
        }
    }
