    var inputString = string.Empty; //Your input string here
    var output = new StringBuilder();
    foreach (var c in inputString.ToCharArray())
    {
        if (c.ToString().ToUpper() == c.ToString())
        {
            output.AppendFormat("_{0}_", c);
        }
        else
        {
            output.Append(c);
        }
    }
