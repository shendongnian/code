    public static IEnumerable<string> ReadLines()
    {
      string line;
      while(null != (line = Console.ReadLine()))
        yield return line;
    }
    public static void Main()
    {
      string input = string.Join(ReadLines(), Environment.NewLine);
    }
