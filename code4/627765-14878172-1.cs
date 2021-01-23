    [XmlAttribute("DataType")]
    public string DataType 
    {
        get 
        { 
            return typeof(IPAddress).GetProperty("DataType").GetGetMethod().ReturnType.ToString();
        }
    }
