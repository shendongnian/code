    try
    {
        var idRegEx = "^.*?\s\(id\s(\d{3}-\d{4}-\d{4}-\d{3})\)$";
        var ctIdRegex = "^.*?\s\(ctid\s(\d{4})\)$";
    
        var idMatch = Regex.Replace(textToTest, idRegEx, RegexOptions.IgnoreCase).Groups[1].Value;
        var ctIdMatch = Regex.Replace(textToTest, ctIdRegex , RegexOptions.IgnoreCase).Groups[1].Value;
    }
    catch(ArgumentException)
    {
       // Regex is wrong
    }
    catch(ArgumentOutOfRangeException)
    {
       // No match found on one or the other
    }
