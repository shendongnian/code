    public static void Main(string[] args)
            {
                var list1 = new List<string>{
                "a", "b", "c"
            };
    
                var list2 = new List<string>{
                "c", "d", "e"
            };
    
               IEnumerable<string> dubvalues = list2.Intersect(list1);
    
                foreach (var i in dubvalues)
                {
                    Console.WriteLine(i); // Output is c
                }
            }
