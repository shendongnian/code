    public partial class PARENT
    {
        public PARENT()
        {
            this.CHILDREN = new List<CHILD>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        [JsonConverter(typeof(CollectionOfIds))]
        public virtual ICollection<CHILD> CHILDREN { get; set; }
    }
