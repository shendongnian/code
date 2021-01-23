    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
    namespaces.Add(string.Empty, string.Empty);
    StringWriter sw = new StringWriter();
    XmlSerializer serializer1 = new XmlSerializer(typeof(ResponseObject));
    XmlTextWriter xmlWriter = new XmlTextWriter(sw);
    
    //Creating new object and assign the existing list and status
    ResponseObject resp = new ResponseObject();
    resp.studentList = ls;
    resp.status = 1;
    
    //Serialize with the new object
    serializer1.Serialize(xmlWriter, resp, namespaces);
    sw.ToString()
    
