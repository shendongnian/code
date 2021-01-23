    public static string RemoveNonUnicodeLetters(string input)
    {
           StringBuilder sb = new StringBuilder();
           foreach (char c in input)
           {
                if (Char.IsLetter(c))
                    sb.Append(c);
           }
    
                return sb.ToString();
    }
    
        
    static readonly Regex nonUnicodeRx = new Regex("\\P{L}");
    public static string RemoveNonUnicodeLetters2(string input)
    {
         return nonUnicodeRx.Replace(input, "");
    }
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        StringBuilder sb = new StringBuilder();
          
        //generate guids as input
        for (int j = 0; j < 1000; j++)
        {
            sb.Append(Guid.NewGuid().ToString());
        }
        string input = sb.ToString();
        sw.Start();
        for (int i = 0; i < 1000; i++)
        {
            RemoveNonUnicodeLetters(input);
        }
        sw.Stop();
        Console.WriteLine("SM: " + sw.ElapsedMilliseconds);
        sw.Restart();
        for (int i = 0; i < 1000; i++)
        {
            RemoveNonUnicodeLetters2(input);
        }
        sw.Stop();
        Console.WriteLine("RX: " + sw.ElapsedMilliseconds);
    }
