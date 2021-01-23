    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace FooWrapper
    {
        class Program
        {
            private static List<Foo> list = new List<Foo>();
    
            static FooWrapper FindItem(int id)
            {
                return new FooWrapper(list.Where(o => o.PrimaryKey == id));
            }
    
            static void Main(string[] args)
            {
                list.Add(new FooA() { PrimaryKey = 1, Title = "aaa" });
                list.Add(new FooB() { PrimaryKey = 1, Age = 123 });
    
                // test the implicit cast to Foo type. this prefers the FooA type.
                Foo item = FindItem(1);
                Console.WriteLine(item.PrimaryKey + " - " + item.GetType().Name);
    
                // retrieve the FooWrapper and cast it to FooA type.
                var itema = (FooA)FindItem(1);
                Console.WriteLine(itema.PrimaryKey + " - " + itema.Title + " - " + itema.GetType().Name);
    
                // retrieve the FooWrapper and cast it to FooB type. The wrapper instance 
                // retrieved is the same, but the cast retrieves the correct type
                var itemb = (FooB)FindItem(1);
                Console.WriteLine(itemb.PrimaryKey + " - " + itemb.Age + " - " + itemb.GetType().Name);
            }
        }
    
        public sealed class FooWrapper
        {
            private FooA _a;
            private FooB _b;
    
            public FooWrapper(IEnumerable<Foo> items)
            {
                FooA a;
                FooB b;
                foreach (var i in items)
                {
                    a = i as FooA;
                    if (a != null)
                    {
                        this._a = a;
                    }
                    else
                    {
                        b = i as FooB;
                        if (b != null)
                            this._b = b;
                    }
                }
            }
    
            public static implicit operator Foo(FooWrapper obj)
            {
                if (obj == null)
                    return null;
    
                return obj._a == null ? (Foo)obj._b : obj._a;
            }
    
            public static explicit operator FooA(FooWrapper obj)
            {
                if (obj == null)
                    return null;
    
                return obj._a;
            }
    
            public static explicit operator FooB(FooWrapper obj)
            {
                if (obj == null)
                    return null;
    
                return obj._b;
            }
        }
    
        public abstract class Foo
        {
            public int PrimaryKey { get; set; }
        }
    
        public class FooA : Foo
        {
            public string Title { get; set; }
        }
    
        public class FooB : Foo
        {
            public int Age { get; set; }
        }
    }
