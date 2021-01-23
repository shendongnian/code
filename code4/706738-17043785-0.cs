    List<int> Branches = new List<int>();
    Branches.Add(1);
    Branches.Add(2);
    Branches.Add(3);
    XElement xmlElements = new XElement("Branches", Branches.Select(i => new XElement("branch", i)));
    System.Console.Write(xmlElements);
    System.Console.Read();
