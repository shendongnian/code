    using System;
    //Object of this class will be given to using hence IDisposable
    class C : IDisposable        
    {
        public void UseLimitedResource()
        {
            Console.WriteLine("Using limited resource...");
        }
    
        //Dispose() Method
        void IDisposable.Dispose()
        {
            Console.WriteLine("Disposing limited resource.");
        }
    }
    
    class Program
    {
        static void Main()
        {
            using (C c = new C())  //Object of Class defined above
            {
                c.UseLimitedResource();
                //Object automatically disposed before closing.
            }                            
            Console.WriteLine("Now outside using statement.");
            Console.ReadLine();
        }
    }
