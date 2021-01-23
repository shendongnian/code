    // Open the xml file and create the element list
    XDocument doc = XDocument.Load("C://data.xml");
    var ElementList = doc.Root.Elements();
    
    // Crate the Employee list and populate
    List<Employee> list = new List<Employee>();
    foreach (XElement item in listaElementi)
    {
       list.Add(new Employee { EmployeeName = item.Descendants().First().Value, EmployeeId = item.Descendants().Last().Value });
    }
