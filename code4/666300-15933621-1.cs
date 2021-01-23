    // define your 'real field' as string, byte[] and/or define column type ntext, binary etc.
    public string Value {get;set;}
    // and make a wrapper property
    [NotMapped]
    public object ValueWrapper
    {
        get { return YourParser.Deserialize(this.Value); }
        set { this.Value = value.Serialize(); }
    }  
