    public class AppSetting
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("pType")]
        public string pType{ get; set; }
        [XmlIgnore()]
        public object Value{ get; set; }
        [XmlText()]
        public string AttributeValue 
        {
            get { return Value.ToString(); }
            set {
            //this is where you have to have a MESSY type switch
            switch(pType) 
            { case "System.String": Value = value; break;
              //not showing the whole thing, you get the idea
            }
        }
    }
