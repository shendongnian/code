    class Foo { }
    
        // I want to use this kind of like a typedef, to avoid writing List<Foo> everywhere.
        class FooList : List<Foo> {}
    
        class Program
        {
            static void Main(string[] args)
            {
                FooList l = new FooList();
                l.AddRange(GetFooList().Select(foo => foo));
    
                Console.ReadLine();
            }
    
            // Suppose this is some library method, and i don't have control over the return type
            static List<Foo> GetFooList()
            {
                return new List<Foo>();
            }
        }
