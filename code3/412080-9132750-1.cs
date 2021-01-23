    public static IQueryable<Item> GetItemsFromXml(XDocument document)
    {
        return (from a in document.Root.Elements("items") 
                select new Item 
                {
                    Id = a.Attribute("id").Value, 
                    Type = a.Attribute("type").Value, 
                    Modified = a.Attribute("modified").Value 
                }); 
    }
