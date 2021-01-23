    public void Replace()
    {
        var myString = "(In£dex N#£umber;#)";
        var replacement = String.Empty;
        var regExPattern = @"\d|[#£;]";
        var regEx = new Regex(regExPattern);
        var result = regEx.Replace(myString, replacement);
    
        Console.WriteLine("The replaced string: {0}", result); 
    }
