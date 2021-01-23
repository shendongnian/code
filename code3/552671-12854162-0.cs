    [Serializable]
    public class DataClass
    {       
        public DataClass()
        {
        }
         
        public DataClass(string name, string description)
        {
            Name = name;
            Description = description;
    
            this.Dictionary = new Dictionary<string, HashSet<DataClass>>();
        }
    
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        public Dictionary<string, HashSet<DataClass>> Dictionary { get; set; }
    }
