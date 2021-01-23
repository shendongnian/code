    var line = "field1|field2|\"field3\"|field4";
    var pattern = string.Format("{0}(?=([^\"]*\"[^\"]*\")*[^\"]*$)", Regex.Escape("|")); 
    //{0} in pattern is CSV separator. To get current use System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator
    var splitted = Regex.Split(line, pattern, RegexOptions.Compiled | RegexOptions.ExplicitCapture);
    
    foreach (var s in splitted)
        Console.WriteLine(s);
