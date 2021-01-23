    class A
            {
                public int prop1 { get; set; }
                public int prop2 { get; set; }
            }
        
        class Program
        {
            static IEnumerable<T> GenericOrderByDescending<T>(IEnumerable<T> arg, string property, int take)
            {
                return arg.OrderByDescending(x => x.GetType().GetProperty(property).GetValue(x, null)).Take(take);
            }
            
            static void Main(string[] args)
            {           
                IEnumerable<A> arr = new List<A>()
                                         {
                                             new A(){ prop1 = 1, prop2 = 2},
                                             new A(){prop1 = 2,prop2 =2},
                                             new A(){prop1 = 3,prop2 =2},
                                             new A(){prop1 = 441,prop2 =2},
                                             new A(){prop1 = 2,prop2 =2}
                                         };
    
                foreach(var a1 in GenericOrderByDescending<A>(arr, "prop1", 3))
                {
                    Console.WriteLine(a1.prop1);
                }
            }
        }
