    private object m_object = null;
    
    [XmlAttribute("value")]
    public string ObjectValue
    {
    get { return m_object.ToString();}
    set { m_object = value;}
    }
    
    [XmlIgnore]
    public object Value
    {
    get { return m_object; }
    set { m_object = value; }
    }
