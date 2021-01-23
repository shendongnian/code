    [Serializable]
    public class Pitanje {
        public Pitanje() { }
        
        [XmlAttribute]
        public Boolean tacan { get; set; }
     }
        
    [Serializable]
    [XmlRoot("Pitanja", Namespace = "", IsNullable = false)]
    public class PitanjaModelList {
       [XmlElementAttribute("Pitanje", Form = XmlSchemaForm.Unqualified)]
       public List<Pitanje> PitanjaList { get; set; }
    }
