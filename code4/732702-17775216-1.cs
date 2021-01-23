        XDocument doc = XDocument.Load("test.xml");
        string nodeName = "Mike";
        var query = from el in doc.Descendants("dogs")
                    where (string)el.Attribute("name") == nodeName
                    select new XmlResult(){
                        Name = nodeName,
                        Breed = (string)el.Element("breed")
                        Sex = (string)el.Element("sex")
                    };
        foreach (string data in query)
        {
            Console.WriteLine(data.Name);
            Console.WriteLine(data.Breed);
            Console.WriteLine(data.Sex);
        }
