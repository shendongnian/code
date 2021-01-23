    Hashtable t = new Hashtable();
    t.Add("Key", "Adam");
    // Get the key/value entries.
    var itemEntry = t.OfType<DictionaryEntry>().Where(de => (de.Value as string) == "Adam");
    // Get just the values.
    var items = t.Values.OfType<string>().Where(s => s == "Adam");
    // Get just the keys.
    var itemKey = t.Keys.OfType<string>().Where(k => k == "Key");
