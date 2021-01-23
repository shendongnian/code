    //this is how plugin developer would implement the interface
    using Shared;//<-----the shared dll is included
    namespace PlugInApp 
    {
        public class plugInClass : IWrite //its interface implemented
        {
            public  void write() 
            {
                Console.Write("High from plugInClass");
            }
        }
    }
