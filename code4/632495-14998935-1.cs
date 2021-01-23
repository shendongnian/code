      var query = 
          from l in xmlDoc.Root.Elements()
          select new {
             Id = (int)l.Attribute("id"),
             Subjects = l.Element("Subjects")
                         .Elements("subject")
                         .Select(s => (string)s.Attribute("SubjectName"))
                         .ToList()
          };
       foreach (var item in query)
       {
           Console.WriteLine(item.Id);
           foreach (var name in item.Subjects)
               Console.WriteLine(name);
       }
