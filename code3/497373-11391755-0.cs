    for(var i = 1; i < products.Count; i++)
            {
                xml.Append(string.Format("<Message>"));
                xml.Append(string.Format("<MessageID>" + i + "</MessageID>"));
    }
