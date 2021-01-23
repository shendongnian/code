    var cars = 
        XDocument.Load("a.xml")
            .Descendants("Make")
            .Select(make => new
            {
                Name = make.Attribute("Name").Value,
                Models = make.Descendants("Model")
                             .Select(model => new{
                                 Name = (string)model.Attribute("Name"),
                                 Year = (int)model.Attribute("Year"),
                                 Price = (int)model.Element("Price")
                             })
                             .ToList()
            })
            .ToList();
    string userInput="Civic";
    var price = cars.SelectMany(c => c.Models).First(m => m.Name == userInput).Price;
