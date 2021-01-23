    // a sample base class
    class KBase  {
         public readonly int value;  // making it readonly means it can only be assigned to once, and that has to happen during a constructor.
         public KBase ( int startValue ) { value = startValue; }
    }
    class KHandler : KBase
    {
        public readonly string name = "wut";
    
        // this is a parameterless constructor, whose implementation invokes another constructor ( the one below ) of this class
        public KHandler () : this ( "huh" ) {
        }
        
        // this is a 1 parameter constructor, whose implementation ensures KBase is properly initialized, and then proceeds to initialize its part of the new instance.
        public KHandler ( string val ) : base ( 3 ) { 
            name = val;
        }
    }
    class Test {
        static void Main()
        {
            // this next line calls the parameterless constructor I defined above
            KHandler handler = new KHandler();  
            // and this next line calls the 1 parameter constructor
            KHandler handler2 = new KHandler("something else");
            Console.WriteLine("All Good 1"+handler.name);
            Console.WriteLine("All Good 2"+handler2.name);
        }
    }
