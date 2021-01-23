    public void Load()
    {
        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    
        var xdoc = XDocument.Load(fs);
        var units = from u in xdoc.Descendants("Unit")
                    select new {
                       Id = (int)u.Element("id"),
                       Name = (string)u.Element("name")
                    };
    
        foreach(var unit in units)
        {
           // thanks God for IntelliSense!
           MessageBox.Show(String.Format("ID:{0}\r\nName:{1}", unit.Id, unit.Name));
        }
    }
