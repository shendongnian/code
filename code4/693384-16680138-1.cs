            string xml = "<User_Security><bob><group>s1, a2, b3</group></bob><alice><group>y3, c2</group></alice></User_Security>";
            var e = XElement.Load(new XmlTextReader(xml, XmlNodeType.Element, null));
            
           var users = e.Elements()
            .Select(x => 
                new {
                    Name = x.Name, 
                    Groups = x.Element("group").Value.Split(new[] { ',' })
                             .Select(s => s.Trim())
                             .ToList() 
                }).ToList();
            
            
    users.ForEach(u =>
        {
            Console.WriteLine(u.Name);
            u.Groups.ForEach(g => Console.WriteLine(" - " + g));
        });
