      List<Peoples> peopleList = new List<Peoples>(); 
      peopleList.Add(new Peoples() { Name = "xxx", Age = 23 });
      peopleList.Add(new Peoples() { Name = "yyy", Age = 25 });
      var people =  (from item in peopleList
      select new XElement("people",
                                new XElement("name", item.Name),
                                new XElement("age", item.Age)
                            ));
      XElement root = new XElement("Peoples");
      root.Add(people);
      XDocument xDoc = new XDocument(
                             new XDeclaration("1.0", "utf-8", "yes"),
                             root);
      string str = xDoc.ToString();
