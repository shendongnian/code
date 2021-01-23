    XDocument xmlDoc = XDocument.Parse(dataInXmlFile);
    var Categories = 
        (from Category in xmlDoc.Descendants("Category")
         select new Notch()
         {
             name = (string)Category.Attribute("name"),
             titles = Category.Element("Articles").Elements("article")
                              .Select(a => (string)a).ToList();            
         }).ToList();
    
     foreach(var doc in Categories)
     {
        foreach(var sec in doc.titles)
        {
             // use title
        }
     }
    
    NotchsList.ItemsSource = Categories.ToList();
