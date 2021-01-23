    private string _encryptedPersonalData;
    private string _personalData;                    
    
    [XmlIgnore]
    public PersonalData
    {                
        set { _personalData = value;}                
        get { return _personalData; }            
    }
 
    public string EncryptedPersonalData
    {
        get { return _encryptedPersonalData; }
        set { _encryptedPersonalData = value; }
    }
    [OnDeserializingAttribute()]
    internal void DecryptPersonalData(StreamingContext context)
    { 
        // Decrypt data here    
    }
    [OnSerializingAttribute()]
    internal void EncryptPersonalData(StreamingContext context)
    { 
        // Encrypt data here    
    }
