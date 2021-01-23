    static string[] SplitArgs(string input)
    {
        var args = new List<string>();
        var parts = input.Split(' ');
        for (int ii = 0; ii < parts.Length; ++ii)
        {
            // if it starts with a quote, search to the end
            // NB: this does not handle the case of --x="hello world"
            // an arguments post processor is required in that case
            if (parts[ii].StartsWith("\""))
            {
                var builder = new StringBuilder(parts[ii].Substring(0));
                while (ii + 1 < parts.Length
                    && !parts[++ii].EndsWith("\""))
                {
                    builder.Append(' ');
                }
                // if we made it here before the end of the string
                // it is the end of a quoted argument
                if (ii < parts.Length)
                    builder.Append(parts[ii].Substring(0, parts[ii].Length - 1));
                args.Add(builder.ToString());
            }
            else
                args.Add(part[ii]);
        }
        return args.ToArray();
    }
