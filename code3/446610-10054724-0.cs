    var dataSet = from r in something.Elements("chapter")
                   select new dictChapter{
                       Name = r.Attribute("Name").Value,
                       Desc1 = ShowDesc1 ? r.Attribute("Description1").Value : String.Empty,
                       Desc2 = ShowDesc2 ? r.Attribute("Description2").Value : String.Empty,
                       Desc3 = ShowDesc3 ? r.Attribute("Description3").Value : String.Empty,
    
                   };
