    string test = "{strong:lorem ip{i:su{b:m}m}m dolar} {strong:so strong}";
    Regex tagParse = new Regex(
        @"\{(?<outerTag>\w*)
            (?>
                (?<DEPTH>\{(?<innerTags>\w*))
                |
                (?<-DEPTH>\})
                |
                :?(?<innerContent>[^\{\}]*)
            )*
            (?(DEPTH)(?!))
                  
            ", RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
            
    MatchCollection matches = tagParse.Matches(test);
    foreach (Match m in matches)
    {
        StringBuilder sb = new StringBuilder();
        List<string> tags = new List<string>();
        tags.Add(m.Groups["outerTag"].Value);
        foreach (Capture c in m.Groups["innerTags"].Captures)
            tags.Add(c.Value);
        List<string> content = new List<string>();
        foreach (Capture c in m.Groups["innerContent"].Captures)
            content.Add(c.Value);
        if (tags.Count > 1)
        {
            for (int i = 0; i < content.Count; i++)
            {
                if (i >= tags.Count)
                    sb.Append("</" + tags[tags.Count - (i - tags.Count + 1)] + ">");
                else
                    sb.Append("<" + tags[i] + ">");
                sb.Append(content[i]);
            }
            sb.Append("</" + tags[1] + ">");
        }
        else
        {
            sb.Append("<" + tags[0] + ">");
            sb.Append(content[0]);
        }
        sb.Append(m.Groups["outerContent"].Value);
        sb.Append("</" + m.Groups["outerTag"].Value + ">");
        Console.WriteLine(sb.ToString());
    }  
