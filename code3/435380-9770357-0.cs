    using System.Text.RegularExpressions;
    foreach(var match in Regex.Matches(theText, "[0-9]+")
    {
        var number = int.Parse(match.Value);
    }
