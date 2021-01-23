    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                var test = new MyClass();
                // ...
                int sum = test.All().Sum();
            }
        }
        public class MyClass
        {
            public int C1 { get; set; }
            public int C2 { get; set; }
            public int C3 { get; set; }
            // ...
            public int Cn { get; set; }
            public IEnumerable<int> All()
            {
                yield return C1; 
                yield return C2; 
                yield return C3; 
                // ...
                yield return Cn; 
            }
        }
    }                                                                                            
