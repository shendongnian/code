    [XmlAttribute("DataType")]
    public string DataType 
    {
        get 
        { 
            return typeof(Computer).GetProperty("StorageName").GetGetMethod().ReturnType.ToString();
        }
    }
