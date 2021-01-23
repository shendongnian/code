    var input = "D1-D5";
    string output = string.Empty;
    if (input.IndexOf("-") > 0)
    {
        var values = input.Split('-');
        int first = int.Parse(System.Text.RegularExpressions.Regex.Match(values[0], @"\d+").Value);
        int second = int.Parse(System.Text.RegularExpressions.Regex.Match(values[1], @"\d+").Value);
    
        for (int i = first; i <= second; i++)
        {
            output += "D" + i + ",";
        }
        output = output.Remove(output.Length - 1);
    }
