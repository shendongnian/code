    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tpwebservice.x.com", Order=5)] 
    [System.Xml.Serialization.XmlElementAttribute("ClientAccNumber", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)] 
    public string ClientAccNumberStr; 
    [System.Xml.Serialization.XmlIgnoreAttribute]
    public System.Nullable<long> ClientAccNumber {
      get {
        if (string.IsNullOrEmpty(ClientAccNumberStr))
          return null;
        return long.Parse(ClientAccNumberStr);
      }
      set {
        if (!value.HasValue) {
          ClientAccNumberStr = null;
        } else {
          ClientAccNumberStr = value.Value.ToString();
        }
      }
    }
