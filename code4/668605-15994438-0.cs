    public class PhoneNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Number { get; set; }
        public bool Primary { get; set; }
        [ForeignKey("Contact"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
