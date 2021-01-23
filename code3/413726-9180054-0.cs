    public static void Main(string[] args)
    {
        List<string> inputValues = new List<string>() { "ABC", "G", "WY" };
        List<string> results = new List<string>();
    
        int permutations = (int)Math.Pow(2.0, (double)inputValues.Count);
    
        for (int i = 0; i < permutations; i++)
        {
            int mask = 1;
            StringBuilder line = new StringBuilder();
            for (int j = 0; j < inputValues.Count; j++, mask <<= 1)
            {
                if (j > 0)
                    line.Append("_");
                if ((i & mask) == 0)
                {
                    line.Append(inputValues[j]);
                }
                else
                {
                    line.Append("ALL");
                }
            }
    
            results.Add(line.ToString());
        }
    
    
        foreach (string s in results)
        {
            Console.WriteLine(s);
        }
    
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
