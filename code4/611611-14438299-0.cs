    var events = _ma.GetEvents();
    string result = "";
    using (StringWriter writer = new StringWriter())
    {
        foreach (var ev in events)
        {
            _ma.Layout.Format(writer, ev);
            writer.Write(Environment.NewLine);
        }
        result = writer.ToString();
    }
