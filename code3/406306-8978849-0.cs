    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Dynamic;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            protected dynamic Get2(int id)
            {
                Func<dynamic, bool> check = x => x.ID == id;
                return Enumerable.FirstOrDefault<dynamic>(this.Get(), check);
            }
    
            protected dynamic Get(int id)
            {
                return Get().FirstOrDefault(x => x.ID == id);
            }
    
            internal IEnumerable<dynamic> Get()
            {
                dynamic a = new ExpandoObject(); a.ID = 1;
                dynamic b = new ExpandoObject(); b.ID = 2;
                dynamic c = new ExpandoObject(); c.ID = 3;
                return new[] { a, b, c };
            }
    
            static void Main(string[] args)
            {
                var program = new Program();
                Console.WriteLine(program.Get(2).ID);
                Console.WriteLine(program.Get2(2).ID);
            }
    
        }
    
    }
