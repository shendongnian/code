    using System;
    
    namespace Programs
    {
        public interface IBar { }
        public interface IFoo : IBar { }
        public interface IZoo : IFoo { }
    
        public  class Program
        {
            public static void Main(string[] args)
            {
                Type[] types = typeof(IZoo).GetInterfaces();
    
                foreach ( var t in types )
                {
                    Console.WriteLine(t.ToString());
                }
            }
        }
    }
