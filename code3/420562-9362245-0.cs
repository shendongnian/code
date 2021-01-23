     class Program
        {
            static void Main(string[] args)
            {
                increaseMemoryUsage();
    
                Console.WriteLine("Hit enter to force GC");
                Console.ReadLine();
    
                GC.Collect();
    
                Console.ReadLine();
            }
    
            private static void increaseMemoryUsage()
            {
                var testvectors = new List<List<float>>();
                const int vectorNum = 250 * 250;
                var rand = new Random();
    
                for (var i = 0; i < vectorNum; i++)
                {
                    var vec = new List<Single>();
    
                    for (var j = 0; j < 1000; j++)
                        vec.Add((Single)rand.NextDouble());
                    
                    testvectors.Add(vec);
                }
            }    
        }
