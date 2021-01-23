    var pattern = keyword.Split()
                         .Aggregate(new StringBuilder(),
                                    (sb, s) => sb.AppendFormat(@"(?=.*\b{0}\b)", s),
                                     sb => sb.ToString());
    if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
    {
        // contains all keywords
    }
