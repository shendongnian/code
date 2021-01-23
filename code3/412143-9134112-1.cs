    string[] lines = new string[]
    {
        "\"Date\",\"Description\",\"Original Description\",\"Amount\",\"Type\",\"Category\",\"Name\",\"Labels\",\"Notes\"",
        "\"2/02/2012\",\"ac\",\"ac\",\"515.00\",\"a\",\"b\",\"\",\"javascript://\"",
        "\"2/02/2012\",\"test\",\"test\",\"40.00\",\"a\",\"d\",\"c\",\"\",\" \"",
    };
    string[][] values =
        lines.Where(line => line.Length >= 2)
             .Select(line => 
                 line.Substring(1, line.Length - 2)
                     .Split(new string[] { "\",\"" }, StringSplitOptions.None)
                     .Select(val => val.Replace("\\\\", "\\")
                                       .Replace("\\\"", "\"")).ToArray()).ToArray();
