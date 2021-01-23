    public void ConvertObjectToXml(Employee employee )
    {
        MemoryStream Stream = new MemoryStream();
        //To remove the default xml name space
        XmlSerializerNamespaces XmlNS = new XmlSerializerNamespaces();
        XmlNS.Add("", "");
        XmlSerializer XmlSerializer = new XmlSerializer(employee .GetType());
        XmlSerializer.Serialize(Stream, employee , XmlNS);
        Stream.Flush();
        Stream.Seek(0, SeekOrigin.Begin);
        XDocument xDocument = XDocument.Load(Stream);
		//Paasing the "Basic" as string
        XElement xElement = xDocument.Descendants("Basic").First();
        string xpath = GetPath(xElement);
	      //Paasing the "Course" as string
        XElement XElement1 =xDocument.Descendants("Course").First();
        string xpath1 = GetPath(XElement1);
    }
    public static string GetPath(XElement element)
    {
        return string.Join("/", element.AncestorsAndSelf().Reverse()
            .Select(e => 
            {
                var index = GetIndex(e); 
                if (index == 1) 
                {
                    return e.Name.LocalName; 
                }
                return string.Format("{0}[{1}]", e.Name.LocalName, GetIndex(e)); 
            })); 
    } 
    public static int GetIndex(XElement element) 
    {
        var i = 1; 
        if (element.Parent == null) 
        {
            return 1; 
        }
        foreach (var e in element.Parent.Elements(element.Name.LocalName)) 
        {
            if (e == element)
            { 
                break; 
            }
            i++;
        }
        return i; 
    } 
