    class Foo
    {    
        public Foo(string p1, string p2)
        {
            Property1 = p1;
            Property2 = p2;
        }
        string Property1 { get; set; } 
        string Property2 { get; set; }
        public void DoSomething()
        {
            // *** Replace this with something valid to your real code
            if(!string.IsNullOrEmpty(Property1) || !string.IsNullOrEmpty(Property2)) 
                return; // Don't want to continue if not initialized
            // Do something here
        }
    }
