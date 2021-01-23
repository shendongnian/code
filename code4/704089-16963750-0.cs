    var xDoc = XDocument.Load(fname);
    var applicants = xDoc.Descendants("Applicants")
                         .OrderBy(a=>(int)a.Element("PersonID"))
                         .ToList();
    applicants.ForEach(a=>a.Remove());
    xDoc.Root.Element("Application").Add(applicants);
    xDoc.Save(fname);
