    XDocument xdoc = new XDocument();
    xdoc.Add(new XElement("employees"));
    for (var i = 0; i < 3; i++)
    {
         Console.WriteLine("Name: ");
         var name = Console.ReadLine();
          Console.WriteLine("Nationality:");
          var country = Console.ReadLine();
          
          XElement el = new XElement("employee");
          el.Add(new XElement("name", name), new XElement("country", country));
          xdoc.Element("employees").Add(el);
    }
