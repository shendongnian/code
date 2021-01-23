    public static string ToWrappedString(this ObjectQuery query, out ObjectParameterCollection parameters)
    {
        var trace = query.ToTraceString();
        parameters = query.Parameters;
        var positions = query.GetPropertyPositions();
        // the query should be SELECT\n
        //  Column AS NNN
        //  FROM
        // so we regex this out
        var regex = new Regex("^SELECT(?<columns>.*?)FROM", RegexOptions.Multiline);
        var result = regex.Match(trace.Replace(Environment.NewLine, ""));
        var cols = result.Groups["columns"];
        // then we have the columns so split to get each
        const string As = " AS ";
        var colNames = cols.Value.Split(',').Select(a => a.Substring(a.IndexOf(As, StringComparison.InvariantCulture) + As.Length)).ToArray();
        var wrapped = "SELECT " + String.Join(Environment.NewLine + ", ", colNames.Select((a, i) => string.Format("{0}{1} [{2}]", a, As, positions[i]))) + " FROM (" + trace
                      + ") WrappedQuery ";
        return wrapped;
    }
