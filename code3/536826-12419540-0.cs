    var SVCs = XElement.Load("demoFile.xml");
    var result = from svc in SVCs.Elements()
                    where svc.Element("id").Value == "002"
                    select svc;
    foreach (var entry in result)
    {
        Console.WriteLine(entry);
        Console.WriteLine(entry.Element("request").Value);
    }
