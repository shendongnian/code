    [Serializable]
    [XmlType(TypeName = "Rules")]
    public class Rules
    {
        // Make fields propertys so they will be serialized
        public string eN { get; set; }      //Name
        public Boolean bE { get; set; }     //Whether blocked entirely
        public int min { get; set; }        //Minutes they are allowed if blocked
        public Boolean bot { get; set; }    //Create notification if allowance exceed
        public string onE { get; set; }     //Nothing or CLOSE Process
        public Rules(string na, Boolean b)
        {
          
        }
        public Rules()
        {
        }
    }
