    static Regex QuotedTextRegex = new Regex(@"("".*?"")", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    
    var result = QuotedTextRegex
                    .Split(sourceString)
                    .Select(v => new
                        {
                            value = v,
                            isQuoted = v.Length > 0 && v[0] == '\"'
                        });
