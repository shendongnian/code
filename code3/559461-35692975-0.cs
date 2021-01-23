    using System.Text.RegularExpressions;
    
    string aplhaNumericString = "A01", alphabeticalString ="AAA";
    Regex.Replace(aplhaNumericString,@"\d","");
    Regex.Replace(alphabeticalString,@"\d","");
