    IList<KeyValuePair<string, Type>> typeIndicators = classNames.Select(x => {
        Type t = Type.GetType(x);
        string indicator = (string)t.GetField("MYINDICATOR", BindingFlags.Public | BindingFlags.Static).GetValue(null);
        return new KeyValuePair(indicator, t);
    });
    while (!sr.EndOfStream)
    {
        line = sr.ReadLine();
        foreach (var types in typeIndicators)
        {
            if (line.Contains(types.Key))
            {
                 IParseLine pl = Activator.CreateInstance(types.Value) as IParseLine;
                 if (pl != null)
                 {
                     string parsedString = pl.ParseLine(line);
                 }
            }
        }
    }
