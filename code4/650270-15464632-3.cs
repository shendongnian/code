    public class Synonym
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int SynonymId { get; set; }
    
        [ForeignKey("Tag"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagId { get; set; }
        public string Name { get; set; }
        public virtual Tag Tag { get; set; }
    }
