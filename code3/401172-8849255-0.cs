    [Table("Bank")]
    public class Bank
    {
        [key]
        public int Id { get; set; }
        [Column("BankName")]
        public string Name { get; set; }
        [NotMapped]
        public bool IsActive { get; set; }
    }
