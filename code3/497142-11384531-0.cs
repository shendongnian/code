    static void Main(string[] args)
    {
        string input = "<br>Hello<br/>World!";
    
        input = EscapeHtmlBr(input);
        var result = Sanitizer.GetSafeHtmlFragment(input);
        result = UnescapeHtmlBr(result);
    
        Console.WriteLine(result);
    }
    
    const string BrMarker = @"|br|";
    
    private static string UnescapeHtmlBr(string result)
    {
        result = result.Replace(BrMarker, "<br />");
    
        return result;
    }
    
    private static string EscapeHtmlBr(string input)
    {
        input = input.Replace("<br>", BrMarker);
        input = input.Replace("<br />", BrMarker);
        input = input.Replace("<br/>", BrMarker);
    
        return input;
    }
