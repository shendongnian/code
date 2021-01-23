    public class Test
    {
        [XmlIgnore]
        public String Header1 { get; set; }
    
        [XmlIgnore]
        public String Header2 { get; set; }
        
        [XmlElement("HeaderText")]
        public String[] HeaderText
        {
            get{  return new[]{Header1,Header2};   }
            set{  if(value.Length == 2) { Header1 = value[0]; Header2 = value[1];} }
        }
    }
