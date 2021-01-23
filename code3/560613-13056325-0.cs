    if (doc.DocumentNode != null)
    {
        var span = doc.DocumentNode.SelectSingleNode("//span[@title='input']");
        if (span != null)
            return span.InnerText;
    }
