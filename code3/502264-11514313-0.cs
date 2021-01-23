    class Program
    {
        static void Main(string[] args)
        {
           var ia = new Dummycls[] { 
               new Dummycls{ A = 1, B = 1 },
               new Dummycls{ A = 1, B = 2 },
               new Dummycls{ A = 2, B = 3 },
               new Dummycls{ A = 2, B = 4 },
               new Dummycls{ A = 1, B = 5 },
               new Dummycls{ A = 3, B = 6 },
    
           };
            var groups = ia.GroupAdjacent(i => i.A);
            foreach (var g in groups)
            {
                Console.WriteLine("Group {0}", g.Key);
                foreach (var i in g)
                    Console.WriteLine(i.ToString());
                Console.WriteLine();
            }
    
            Console.ReadKey();
        }
    }
    
    class Dummycls
    {
        public int A { get; set; }
        public int B { get; set; }
    
        public override string ToString()
        {
            return string.Format("A={0};B={1}" , A , B);
        }
    }
