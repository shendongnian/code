    [XmlElement("MATTYPE")]
    public string MATTYPE { get; set; }
    [XmlElement("MATLTYPE")]
    public string MATLTYPE { get; set; }
    
    public string GetMATLTYPE ()
    {
        var mistakes = new string[] {MATTYPE, MATLTYPE}
    	return mistakes.FirstOrDefault(x => !string.IsNullOrEmpty(x));
    }
