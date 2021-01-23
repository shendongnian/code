    var vegiesList = (from veg in xDoc.Descendants("vegetable")
                      select new Vegetable()
                      {
                           Name = veg.Element("name").Value,
		    			   Recipes = (from re in veg.Elements("recipe")
		 			                  select new Recipe(re.Element("name").Value, re.Element("FilePath").Value)).ToList()
                      })
                      .ToList();
