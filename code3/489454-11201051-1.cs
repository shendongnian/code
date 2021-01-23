    public void DoSomething(NameValuePair[] values)
    {}
    [DataContract]
    class NameValuePair
    {
    [DataMember]
    public string Key {get;set;}
    [DataMember]
    public string Value {get;set;}
    }
