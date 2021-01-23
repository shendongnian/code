    public void DoSomething(NameValuePair[] values)
    {}
    [DataContract]
    public class NameValuePair
    {
    [DataMember]
    public string Key {get;set;}
    [DataMember]
    public string Value {get;set;}
    }
