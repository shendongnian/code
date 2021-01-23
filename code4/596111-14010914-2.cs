    static IEnumerable<Person>Populate(IEnumerable<XElement> children)
    {
         foreach (var child in children)
         {
              var person = new Person
              {
                  Name = ((XText)child.FirstNode).Value.Trim(new[] { ' ', '\r', '\n' }),
                  Children = new PeopleList()
                       
               };
               person.Children.People = new List<Person>();
               foreach (var childrenOf in child.Elements("ol").SelectMany(BuildFromXml))
               {
                   person.Children.People.Add(childrenOf);
               }
               yield return person;
         }
   
    }
    static IEnumerable<Person> BuildFromXml(XElement node)
    {
        return Populate(node.Elements("li"));
    }
