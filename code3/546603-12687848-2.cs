    string xmlpath = "D:\new\test.xml";   
    
    XmlDocument doc = new XmlDocument();
    doc.Load(xmlpath);
    XmlElement root = doc.DocumentElement;
    XmlNodeList employ = root.GetElementsByTagName("Employee");
    list<employee> employees=new <employee>();
    
    foreach (XmlElement emp in employ)
    {
    	string id = emp.GetAttribute("id");
    	string name = emp.GetAttribute("name");
    	string desc = emp.GetAttribute("Prename");
    
        Employee e=new employee();
        e.id=id;
        e.Prename =desc;
        e.Name=name;
       employees.add(e);
    }
