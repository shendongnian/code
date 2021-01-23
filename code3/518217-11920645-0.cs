    public void Foo(string content)
    {
        var entries = content.Split('|');
        for(int i = 0; i < entries.Length; i += 3)
        {
            var text = entries[0 + i];
            var name = entries[1 + i];
            var date = entries[2 + i];
            // TODO: add values to listview.
        }
    }
