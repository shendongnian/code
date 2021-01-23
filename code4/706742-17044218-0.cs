    List<int> Branches = new List<int>();
    Branches.Add(1);
    Branches.Add(2);
    Branches.Add(3);
    
    var branchesXml = Branches.Select(i => new XElement("branch",
                                                        new XAttribute("id", i)));
    var bodyXml = new XElement("Branches", branchesXml);
    System.Console.Write(bodyXml);
