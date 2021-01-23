    IParseLine pl = Activator.CreateInstance(Type.GetType(className)) as IParseLine;
    if (pl != null)
    {
        string parsedString = pl.ParseLine(line);
        // ...
    }
