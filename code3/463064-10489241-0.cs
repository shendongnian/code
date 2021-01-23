    XDocument doc = XDocument.Load("test.xml");
    var query = from l in doc.Descendants("L1")
                let id = l.Attribute("id").Value
                from subject in l.Descendants("Subject")
                select new
                {
                    Id = id,
                    SubjectName = (string)subject.Attribute("SubjectName"),
                    Score = (string)subject.Attribute("Score")
                };
    foreach (var result in query)
    {
        Console.WriteLine(result);
    }
