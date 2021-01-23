    using System.Text.RegularExpressions;
    
    string myString = "some long characters...";
    if(Regex.IsMatch(myString, "\d", RegexOptions.Compiled))
    {
        // String contains numbers
    }
    if(Regex.IsMatch(myString, "\w", RegexOptions.Compiled))
    {
        // String contains letters
    }
