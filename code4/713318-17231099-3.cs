    public static IEnumerable<Tuple<string, string>> GetType6()
    {
        return
            from entry in feed.Descendants(a + "entry")
            let notes = properties.Element(d + "Notes")
            let title = properties.Element(d + "Title")
            select new Tuple<string, string>(notes.Value, title.Value);
    }
