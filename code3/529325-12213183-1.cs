    public static IList<dynamic> GetExpandoFromXml(String file) 
    { 
        var persons = new List<dynamic>();
        var doc = XDocument.Load(file);
        var nodes = from node in doc.Root.Descendants("Person")
                    select node;
        foreach (var n in nodes) 
        {
            dynamic person = new ExpandoObject();
            foreach (var child in n.Descendants()) 
            {
                var p = person as IDictionary<String, object>);
                p[child.Name] = child.Value.Trim();
            }
            persons.Add(person);
        }
        return persons;
    }
