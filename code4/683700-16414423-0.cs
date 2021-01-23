    public IEnumerable<ListViewItem> getDMcollection(string sys)
    {    
        XDocument doc = XDocument.Load(Form1.CSDBpath + Form1.projectName + "\\Data.xml");
        
        var dms = from dm in doc.Descendants("dataModule")
                  where dm.Descendants("system").First().Value == sys
                  select dm;
        
        foreach (var module in dms)
        {
            ListViewItem item = new ListViewItem(new string[]
            {
                module.Element("DMC").Value,
                module.Element("techName").Value,
                module.Element("infoName").Value,
                module.Element("status").Value,
                module.Element("currentUser").Value,
                module.Element("validator").Value,
                module.Element("notes").Value,
                //dm.Element("size").Value + " kb",
                //dm.Element("dateMod").Value
            });
        
            yield return item;    
        }
    }
