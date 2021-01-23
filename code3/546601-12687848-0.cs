	Suggest you something like this would work for u.
         string xmlpath = "D:\new\test.xml";
        XmlDocument xmlborder = new XmlDocument();
	xmlborder.LoadXml(xmlstring);
	xmlborder.Save(xmlpath);
        XmlDocument doc = new XmlDocument();
	doc.Load(xmlpath);
	XmlElement root = doc.DocumentElement;
	string id = root.GetAttribute("id");
	string name = root.GetAttribute("name");
	string desc = root.GetAttribute("Prename");
        Employee e=new employee();
        e.id=id;
        e.Prename =desc;
        e.Name=name;
