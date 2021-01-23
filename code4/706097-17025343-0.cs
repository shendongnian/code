    string replacement1 = "\"";
    string replacement2 = "</span>";
    string pattern = @"(?<=<span style=\")[^\"]+"; //Will match all the style strings
    string pattern1 = @"(?<=<span style=)(.|\s)+\"(?=>[^<>].+</span>)"; //Will match from the first " to the last " before HELLO
    string pattern2 = @"(</span>\s*)+"; //Will match any number of </span> tags
    Regex rgx = new Regex(pattern);
    MatchCollection matches = rgx.Matches(foo);
    foreach (Match match in matches)
        replacement1 += match.Value + ";"; //Builds the new styles string
    replacement1 += "\"";
    Regex rgx = new Regex(pattern1);
    string result = rgx.Replace(foo, replacement1); //Replace the multiple span style tags with a single one
    Regex rgx = new Regex(pattern2); 
    string result = rgx.Replace(foo, replacement2); //Replace the multiple closing span tags with a single one
