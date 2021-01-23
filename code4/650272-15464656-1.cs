    public class Tag
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
    
        public string Name { get; set; }
        public string SynStore {get; set;}
        public IEnumerable<string> Synonyms 
    {
        set { SynStore = String.Join(',', value);}
        get{ return SynStore.split(','); }
    }
    }
