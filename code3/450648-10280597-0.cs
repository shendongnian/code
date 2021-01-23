    public abstract class Result<T> 
    {
        [XmlIgnore]
        public abstract List<T> Items {get;set;}
        [XmlAttribute]
        public int ResultCount
        {
            get
            {
                return this.Items.Count;
            }
            set { }
        }
        
        public Result()
        {
            this.Items = new List<T>();
        }
