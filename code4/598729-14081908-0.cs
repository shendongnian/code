   	 doc = new XDocument(new XElement("Document"));
		doc.Root.Add(
           new XElement("Employees",
             new XElement("Employee",
            new XAttribute("id", 1),
            new XElement("EmpName", "XYZ")),
           new XElement("Departments",
            new XElement("Department",
             new XAttribute("id", 1),
            new XElement("DeptName", "CS")))));
