    public class wordList
    {
        public List<NameId> data { get; set; }
        public wordList() 
        { 
            data = new List<NameId>(); 
        }
    }
    public class NameId
    {
        public string name { get; set; }
        public string id { get; set; }        
    }
