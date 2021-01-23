    class Foo
    {
        public static object FooA(int p1, int p2) 
        { 
            //do something 
        }
        public static object FooB(int p1, int p2) { /* ... */ }
        public static object FooC(int p1, int p2) { /* ... */ }
    }
    
    class Bar
    {
        //You can use Func<int, int, object> instead of a delegate type,
        //but this way is a little easier to read.
        public delegate object Del(int p1, int p2);
    
        public void DoStuff()
        {        
            var classes = new Dictionary<string, Dictionary<string, Del>>();
            classes.Add("Foo", new Dictionary<string, Del>());
            classes["Foo"].Add("FooA", Foo.FooA);
            classes["Foo"].Add("FooB", Foo.FooB);
            classes["Foo"].Add("FooC", Foo.FooC);
    
            //do something with your list of methods
        }
    }
