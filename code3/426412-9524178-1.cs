     private int _acute = 0; // or assign to some more appropriate default
     [XmlIgnore]
     public int Acute
     {
         get { return _acute; }
         set
         {       
               _acute = value;
               NotifyPropertyChanged("Acute");
         }
     }
     // I kept mine as public but may be able to hide it at a minimal level that
     // serialization still works.
     [XmlElement(ElementName = "Acute")]
     public string SerializedAcute
     {
         get { return _acute.ToString(); }
         set
         {   
             Int32.TryParse(value, out _acute)
         }
     }
