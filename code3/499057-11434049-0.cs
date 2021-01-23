    public class cliente
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("Empresa")]
        public int empresa { get; set; }
        public virtual empresa Empresa { get; set; }
    }
