    public class Team
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Column("Id")] //this attribute maps TeamId to the column Id in the database
        public virtual int TeamId { get; set; }
    
        [Display(Name = "Full Name:")]
        public virtual string Name { get; set; }
    }
