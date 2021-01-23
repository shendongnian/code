    public class Notes
    {
       [XmlElement("Type")]
       public string typeName { get; set; }
       [XmlElement("Data")]
       private string _dataValue;
       public string dataValue {
          get {
              if(string.IsNullOrEmpty(_dataValue))
                 return " ";
              else
                 return _dataValue;
          }
          set {
              _dataValue = value;
          }
       }
    }
