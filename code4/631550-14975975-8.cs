    XDocument xmlDoc = XDocument.Parse(dataInXmlFile);
    var Categories = 
        (from Category in xmlDoc.Descendants("Category")
         select new Notch()
         {
             Name = (string)Category.Attribute("name"),
             Titles = Category.Element("Articles").Elements("article")
                              .Select(a => (string)a.Attribute("title")).ToList()
         }).ToList();
    
     foreach(var category in Categories)
     {
        foreach(var title in category.Titles)
        {
             // use title
        }
     }
    
    NotchsList.ItemsSource = Categories.ToList();
