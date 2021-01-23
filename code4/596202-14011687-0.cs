    using System;
    
    namespace Programs
    {
        public interface IBar { }
        public interface IFoo : IBar { }
    
        public  class Program
        {
            public static void Main(string[] args)
            {
                Type[] types = typeof(IFoo).GetInterfaces();
    
                foreach ( var t in types )
                {
                    Console.WriteLine(t.ToString());
                }
            }
        }
    }
