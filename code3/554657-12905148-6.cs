    using System.Text.RegularExpressions;
    ... 
    var Pattern = "[a-z]";
    if (Regex.IsMatch(SomeText, Pattern)) {
    //... there is at least one lower case char in the text
    }
