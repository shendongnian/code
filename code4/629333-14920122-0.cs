    public void Load()
    {
        var doc = XDocument.Load(filePath);
    
        foreach(var unit in doc.Descendants("Unit"))
        {
            string str = string.Format("ID: {0}\r\nName:{0}", unit.Element("id").Value, unit.Element("name").Value);
            MessageBox.Show(str);
        }
    }
