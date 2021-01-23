    private string Parse(IEnumerator<string> tokens)
    {
        string s = "";
        while (tokens.Current != ")") {
            int n;
            if (tokens.Current == "(") {
                if (tokens.MoveNext()) {
                    s += Parse(tokens);
                    if (tokens.Current == ")") {
                        tokens.MoveNext();
                        return s;
                    }
                }
            } else if (Int32.TryParse(tokens.Current, out n)) {
                if (tokens.MoveNext()) {
                    string subExpr = Parse(tokens);
                    var sb = new StringBuilder();
                    for (int i = 0; i < n; i++) {
                        sb.Append(subExpr);
                    }
                    s += sb.ToString();
                }
            } else {
                s += tokens.Current;
                if (!tokens.MoveNext())
                    return s;
            }
        }
        return s;
    }
