    for(var i = 0; i < products.Count; i++)
            {
                xml.Append(string.Format("<Message>"));
                xml.Append(string.Format("<MessageID>" + i+1 + "</MessageID>"));
    }
