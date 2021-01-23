    class Program
        {
            static List<string> sets = new List<string>();
            static int len = 0;
    
            private static void Generte_Sets(string str, int i)
            {
                sets.Add(str[i].ToString());           
    
                if (i + 1 < len)
                    Generte_Sets(str, i + 1);
                else
                {
                    for (int j = 0; j < sets.Count; j++)
                        Console.Write(sets[j]);
                    Console.WriteLine();
                }
    
                sets.Remove(str[i].ToString());          
    
                if (i + 1 < len)
                    Generte_Sets(str, i + 1);
                else
                {
                    for (int j = 0; j < sets.Count; j++)
                        Console.Write(sets[j]);
                    Console.WriteLine();
                }
            }
    
            static void Main(string[] args)
            {
                 string set = "123"; 
                 len = set.Length;
                 Generte_Sets(set, 0);
               
                for (int i = 0; i < sets.Count; i++)
                {
                    Console.WriteLine(sets[i]);
                }
            }
        }
