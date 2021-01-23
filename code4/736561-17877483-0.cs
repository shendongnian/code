    private static void citiesXml()
    {
      const string desc = "Cities that I have recently visited.";
      var list = new List<Tuple<string, string>>();
      list.Add(new Tuple<string, string>("Chicago1", "IN1"));
      list.Add(new Tuple<string, string>("Chicago2", "IN2"));
      list.Add(new Tuple<string, string>("Chicago3", "IN3"));
      var xmlDataStore = new XElement("data", new XElement("description", desc));
      var xmlCities = new XElement("cities");
      for (var i = 0; i < list.Count; i++)
      {
        xmlCities.Add(new XElement("city", 
            new XAttribute("id", i + 1), 
            new XElement("name", list[i].Item1), 
            new XElement("state", list[i].Item2)));
      }
      xmlDataStore.Add(xmlCities);
      Console.WriteLine(xmlDataStore);
      Console.ReadLine();
    }
