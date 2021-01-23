    public class AppSetting
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("pType")]//Note: NOT Null Safe.  NullCheck if any value will ever be null
        public string pType{ get {return Value.GetType().ToString();} set {;} }
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
