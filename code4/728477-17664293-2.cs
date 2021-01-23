    [XmlAttribute("uri")]
    public string SerializedUri
    { 
    	get
    	{
    		return uri.ToString();
    	}
    	set
    	{
    		uri = new Uri(value, UriKind.RelativeOrAbsolute);
    	}
    }
    
    [XmlIgnore]
    public Uri uri { get; set; }
