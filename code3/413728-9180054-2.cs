    public static void Main(string[] args)
    {
        List<string> inputValues = new List<string>() { "ABC", "G", "WY" };
        List<string> results = new List<string>();
    
        int permutations = (int)Math.Pow(2.0, (double)inputValues.Count);
    
        for (int i = 0; i < permutations; i++)
        {
            int mask = 1;
            Stack<string> lineValues = new Stack<string>();
            for (int j = inputValues.Count-1; j >= 0; j--, mask <<= 1)
            {
                if ((i & mask) == 0)
                {
                    lineValues.Push(inputValues[j]);
                }
                else
                {
                    lineValues.Push("ALL");
                }
            }
            results.Add(string.Join("_", lineValues.ToArray())); //ToArray can go away in 4.0(?) I've been told.  I'm still on 3.5
        }
    
        foreach (string s in results)
        {
            Console.WriteLine(s);
        }
    
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
