    class Foo
    {
        public static string FooA(int p1, int p2) 
        { 
            return "FooA:" + p1 + p2; 
        }
        public static string FooB(int p1, int p2) { return "FooB:" + p1 + p2; }
        public static string FooC(int p1, int p2) { return "FooC:" + p1 + p2; }
    }    
    class Bar
    {
        //You can use Func<int, int, object> instead of a delegate type,
        //but this way is a little easier to read.
        public delegate string Del(int p1, int p2);
    
        public static string DoStuff()
        {        
            var classes = new Dictionary<string, Dictionary<string, Del>>();
            classes.Add("Foo", new Dictionary<string, Del>());
            classes["Foo"].Add("FooA", Foo.FooA);
            classes["Foo"].Add("FooB", Foo.FooB);
            classes["Foo"].Add("FooC", Foo.FooC);
    
            //...snip...
            return classes["Foo"]["FooA"](5, 7);
        }
    }
