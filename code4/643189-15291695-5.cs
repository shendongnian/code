    var query = from states in state.Database 
                group states by new { states.State, states.County } into countyGroup
                group countyGroup by countyGroup.Key.State into stateGroup
                select new XElement("State", new XAttribute("name", stateGroup.Key),
                           stateGroup.Select(st => new XElement("County", new XAttribute("name", st.Key.County),
                           st.Select(city => new XElement("City", city.City)))));
    var xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null),
                             new XElement("States", query.ToArray()));
