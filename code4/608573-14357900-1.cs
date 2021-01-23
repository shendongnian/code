    using System.Text.RegularExpressions;
    string body = "hgfhfghgfhfhh fdfdf@mail.com gfhhfhf";
    Match match = Regex.Match(body, @"\b[_a-z0-9-]+(\.[_a-z0-9-]+)*@mail\.com\b",
                              RegexOptions.IgnoreCase); 
    if (match.Success) { 
        // Finally, we get the Group value and display it. 
        string key = match.Groups[1].Value; 
        Console.WriteLine(key); 
    }
