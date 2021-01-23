    static void Main(string[] args)
    {
        string str = "Would \"you\" like to have responses to your \"questions\" sent to you via email?";
        var reg = new Regex("\".*?\"");
        var matches = reg.Matches(str);
        foreach (var item in matches)
        {
            Console.WriteLine(item.ToString());
        }
    }
