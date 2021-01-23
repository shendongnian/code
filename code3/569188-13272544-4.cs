    public class Data
    {
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
    }
    public Data[] sampleData = new Data[] {
        new Data { Level1 = "ELECTRONICS", Level2 = "TELEVISIONS", Level3 = null, Level4 = null },
        new Data { Level1 = "ELECTRONICS", Level2 = "TELEVISIONS", Level3 = "LCD", Level4 = null },
        new Data { Level1 = "ELECTRONICS", Level2 = "PC", Level3 = null, Level4 = null },
        new Data { Level1 = "ELECTRONICS", Level2 = "PORTABLE ELECTRONICS", Level3 = "MP3 PLAYERS", Level4 = "FLASH" },
        new Data { Level1 = "ELECTRONICS", Level2 = "PORTABLE ELECTRONICS", Level3 = "CD PLAYERS", Level4 = null },
        new Data { Level1 = "ELECTRONICS", Level2 = "PORTABLE ELECTRONICS", Level3 = "2 WAY RADIOS", Level4 = null },
    };
    XElement AddNode(string name)
    {
        return new XElement("Node", 
            new XAttribute("Name", name));
    }
    // NOTE: This is not optimized, but you get the idea...
    XDocument BuildHierarchy(IEnumerable<Data> data)
    {
        XElement root = new XElement("Root");
        XDocument xdoc = new XDocument(root);
        XElement level1 = null;
        XElement level2 = null;
        XElement level3 = null;
        XElement level4 = null;
        
        foreach (var item in data)
        {
            // Assumes item.Level1 is never empty...
            if (level1 == null || string.Compare(item.Level1, level1.Attribute("Name").Value) != 0)
            {
                level1 = AddNode(item.Level1);
                root.Add(level1);
                level2 = null;
                level3 = null;
                level4 = null;
            }
                
            if (string.IsNullOrWhiteSpace(item.Level2))
            {
                level2 = null;
                level3 = null;
                level4 = null;
                continue;
            }
            
            if (level2 == null || string.Compare(item.Level2, level2.Attribute("Name").Value) != 0)
            {
                level2 = AddNode(item.Level2);
                level1.Add(level2);
                level3 = null;
                level4 = null;
            }
            
            if (string.IsNullOrWhiteSpace(item.Level3))
            {
                level2 = null;
                level3 = null;
                level4 = null;
                continue;
            }
            
            if (level3 == null || string.Compare(item.Level3, level3.Attribute("Name").Value) != 0)
            {
                level3 = AddNode(item.Level3);
                level2.Add(level3);
                level4 = null;
            }
            if (string.IsNullOrWhiteSpace(item.Level4))
            {
                level4 = null;
                continue;
            }
            
            if (level4 == null || string.Compare(item.Level4, level4.Attribute("Name").Value) != 0)
            {
                level4 = AddNode(item.Level4);
                level3.Add(level4);
            }
        }
        
        return xdoc;
    }
