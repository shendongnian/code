    Match m = Regex.Match(input, regex, RegexOptions.IgnorePatternWhitespace);
    while (m.Success)
    {
       if (m.Groups["base10_Section7"].Success)  {    }
       else
       if (m.Groups["base10_SectionZ"].Success)  {    }
       else
       if (m.Groups["base10_SectionC"].Success)  {    }
       m = m.NextMatch();
    }
