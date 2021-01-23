    static void Main(string[] args)
    {
        Console.WriteLine(SplitByCase("ThisIsMyString"));
        Console.ReadLine();
    }
    
    static string SplitByCase(string str, bool upper = true)
    {
        return String.Join(" ", SplitIntoWords(str, c => Char.IsUpper(c)));
    }
    
    static IEnumerable<String> SplitIntoWords(string str, Func<char, bool> splitter)
    {
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i < str.Length; i++)
        {
            sb.Append(str[i]);
            if (i + 1 == str.Length || splitter(str[i + 1]))
            {
                yield return sb.ToString();
                sb.Clear();
            }
        }
    }
