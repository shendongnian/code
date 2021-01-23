    public static IEnumerable<Item> GetType6()
    {
        return 
            from entry in feed.Descendants(a + "entry")
            let notes = properties.Element(d + "Notes")
            let title = properties.Element(d + "Title")
            select new Item
            {
                Notes = notes.Value, 
                Title = title.Value,
            };
    }
