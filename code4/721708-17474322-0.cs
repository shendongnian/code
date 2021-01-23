    static void Main(string[] args)
    {
        string name = "John xSmith";
        var result = new StringBuilder();
        string[] splitString = name.Split(' ');
        foreach (string partName in splitString)
        {
            if (partName.Length > 1 && partName.StartsWith("x"))
            {
                result.Append(partName.Substring(1));
            }
            else
            {
                result.Append(partName);
            }
            result.Append(" ");
        }
        Console.WriteLine(result.ToString().Trim());
        Console.ReadKey();
    }
