    private static void citiesXml()
    {
      const string desc = "Cities that I have recently visited.";
      // set up a list of all the different cities
      var list = new List<Tuple<string, string>>();
      list.Add(new Tuple<string, string>("Chicago1", "IN1"));
      list.Add(new Tuple<string, string>("Chicago2", "IN2"));
      list.Add(new Tuple<string, string>("Chicago3", "IN3"));
      var xmlDataStore = new XElement("data", new XElement("description", desc));
      var xmlCities = new XElement("cities");
      // loop through the list of cities and create a XElement for each single one
      for (var i = 0; i < list.Count; i++)
      {
        xmlCities.Add(new XElement("city", 
            new XAttribute("id", i + 1), 
            new XElement("name", list[i].Item1), 
            new XElement("state", list[i].Item2)));
      }
      // add the cities to the data store object
      xmlDataStore.Add(xmlCities);
      Console.WriteLine(xmlDataStore);
      Console.ReadLine();
    }
