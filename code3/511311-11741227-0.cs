    static void Main(string[] args)
            {
                List<int> one = new List<int>() { 1, 3, 4, 6, 7 };
                List<int> second = new List<int>() { 1, 2, 4, 5 };
    
                var result = one.Intersect(second);
    
                if (result.Count() > 0)
                    result.ToList().ForEach(t => Console.WriteLine(t));
                else
                    Console.WriteLine("No elements is common!");
    
                Console.ReadLine();
            }
