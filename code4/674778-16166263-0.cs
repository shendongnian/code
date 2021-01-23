    namespace ProgramAgainstInterfaces
    {
        interface IMean : IDisposable
        {
            void foo();
        }
        interface ITry : IMean
        {
        }
        class Meaning : ITry
        {
            public void Dispose()
            {
                Console .WriteLine("Disposing..." );
            }
            public void foo()
            {
                Console .WriteLine("Doing something..." );           
            }
        }
       class DoingSomething
       {
            static void Main( string[] args)
            {
                ITry ThisMeaning = (ITry ) new Meaning ();  // This works
                ThisMeaning.foo();
                ThisMeaning.Dispose();   // The method is available
            }
       }   
    }
