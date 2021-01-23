    public void Message(object sender, string text)
    {
        Entry entry = new Entry(sender, EntryType.Message, text);
        AddEntry(entry);
    }
