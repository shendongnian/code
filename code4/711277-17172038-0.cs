    using System;
    using System.Text.RegularExpressions;
    ...
    string words = "1 2 c 5";
    Match numberMatch = Regex.Match(words, @"[0-9]", RegexOptions.IgnoreCase);
    Match letterMatch = Regex.Match(words, @"[a-zA-Z]", RegexOptions.IgnoreCase);
    // Here we check the Match instance.
    if (numberMatch.Success && letterMatch.Success)
    {
        // there are letters and numbers
    }
