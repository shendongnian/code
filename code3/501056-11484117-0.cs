    public class Owner
    {
        private string _owner;
        [XmlAttribute]
        public string username 
        {
           get { return _owner; } 
           set { _owner = value; }
        }
    }
