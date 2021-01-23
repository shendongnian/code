    XmlRootAttribute root = new XmlRootAttribute("Goals");     
    XmlSerializer serializer = new XmlSerializer(typeof(List<Goals>), root);
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add(string.Empty, string.Empty);   
    using (XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
   {
	serializer.Serialize(xmlWriter, GenerateGoalsData(name, description, 
    progress), ns)
