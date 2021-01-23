    using (var writer = new StringWriter())
    {
        Server.Execute("SomePage.aspx", writer);
        string html = writer.GetStringBuilder().ToString();
    }
