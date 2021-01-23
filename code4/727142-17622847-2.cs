    private string _matltype;
    [XmlElement("MATTYPE")]
    public string MATTYPE { get; set; }
    [XmlElement("MATLTYPE")]
    public string MATLTYPE {
     get { return string.IsNullOrEmpty(_matltype) ? GetMATLTYPE() : _matltype ; }
     set { _matltype = value; }
     }
