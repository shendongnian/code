    private void DisplayFile(string path)
    {
        var doc = XDocument.Load(path);
        var ns = doc.Root.GetDefaultNamespace();    
        var conn = doc.Root.Element(ns + "connection");
    
        label5.Text = conn.Element(ns + "description").Value;
        label6.Text = conn.Element(ns + "sourceId").Value;
    
        // and so on
    }
