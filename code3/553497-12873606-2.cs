    [Serializable]
    public class XMLExample : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public XMLExample()
        {
            ID = "Spaghetti";
            Initial = "Linguini";
            Details = new List<Detail>();
        }
        public string ID { get; set; } // Textbox
        public string Initial { get; set; } // Textbox
        public List<Detail> Details { get; set; } // Datagrid
    }
    [Serializable]
    public class Detail 
    {
        public Detail()
        {
            // default values, if appropriate.
            FirstName = "John"; 
            LastName = "Shaw";
        }
        
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
    }
