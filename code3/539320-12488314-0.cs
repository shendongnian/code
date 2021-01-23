    List<Peoples> peopleList = new List<Peoples>();
                peopleList.Add(new Peoples() { Name = "xxx", Age = 23 });
                peopleList.Add(new Peoples() { Name = "yyy", Age = 25 });
    
                var people = new XElement("Peoples", peopleList.Select(p => 
                                                                 new XElement("people",
                                                                              new XAttribute("name", p.Name),
                                                                              new XAttribute("age", p.Age)
                                                                     ))).ToString();
