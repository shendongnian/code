    var items = doc
       .Elements("user")
       .Elements("order")
       .Where(o => (string)o.Element("date") == bejovo)
       .Elements("menuelem")
       .Select(m => new 
       { 
         Name = (string)m.Element("name"), 
         Price = (int?).Element("price") 
       };
    var names = items.Select(i => i.Name).ToList();
    var price = items.Select(i => i.Price).Sum();
