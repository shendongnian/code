    // Parameters to pass to ParameterizedThreadStart delegate
    // - in this example, it's an Int32 and a String:
    class MyParams
    {
        public int A { get; set; }
        public string B { get; set; }
    
        // Constructor
        public MyParams(int someInt, string someString)
        {
            A = someInt;
            B = someString;
        }
    }
    class MainClass
    {
        MyParams ap = new MyParams(10, "Hello!");
        Thread t = new Thread(new ParameterizedThreadStart(DoMethod));
        t.Start(ap); // Pass parameters when starting the thread
    }
