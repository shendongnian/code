		var doc = XDocument.Load("XMLFile1.xml");
		XNamespace ns = "http://www.w3.org/2005/sparql-results#";
		var products = from x in doc.Descendants(ns + "result")
					 select new Prescriber
					 {
						 EmpId = x.Elements(ns + "binding").Single(e => e.Attribute("name").Value == "EmpId").Element(ns + "uri").Value,
						 EmpName = x.Elements(ns + "binding").Single(e => e.Attribute("name").Value == "EmpName").Element(ns + "uri").Value
					 };
		datagridview.DataSource = products.ToList();
