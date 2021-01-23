    public IEnumerable<Dictionary<string, string>> Parse(TextReader reader)
    {
        var state = new State { Handle = ExpectTableTitle };
        return GenerateFrom(reader)
            .Select(line => state.Handle(line.Split('\t'), state))
            .Where(returnIt => returnIt)
            .Select(returnIt => state.Row);
    }
    private bool ExpectTableTitle(string[] lineParts, State state)
    {
        if (lineParts[0] == "%T")
        {
            state.TableTitle = lineParts[1];
            state.Handle = ExpectFieldNames;
        }
        else
        {
            Console.WriteLine("Expected %T but found '"+lineParts[0]+"'");
        }
        return false;
    }
    private bool ExpectFieldNames(string[] lineParts, State state)
    {
        if (lineParts[0] == "%F")
        {
            state.FieldNames = lineParts.Skip(1).ToArray();
            state.Handle = ExpectRowOrTableTitle;
        }
        else
        {
            Console.WriteLine("Expected %F but found '" + lineParts[0] + "'");
        }
        return false;
    }
    private bool ExpectRowOrTableTitle(string[] lineParts, State state)
    {
        if (lineParts[0] == "%R")
        {
            state.Row = lineParts.Skip(1)
                .Select((x, i) => new { Value = x, Index = i })
                .ToDictionary(x => state.FieldNames[x.Index], x => x.Value);
            state.Row.Add("_tableTitle",state.TableTitle);
            return true;
        }
        return ExpectTableTitle(lineParts, state);
    }
    public class State
    {
        public string TableTitle;
        public string[] FieldNames;
        public Dictionary<string, string> Row;
        public Func<string[], State, bool> Handle;
    }
    private static IEnumerable<string> GenerateFrom(TextReader reader)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
