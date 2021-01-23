    public class Forest
    {    
        public Guid ID { get; set; }  
        public virtual List<Tree> Trees { get; set; }
    }
    public class Tree
    {
        public Guid ID { get; set; }
        public Guid? ForestId {get;set;}
    
        [ForeignKey("ForestId")]
        [ScriptIgnore]
        public virtual Forest Forest {get;set;}
     }
