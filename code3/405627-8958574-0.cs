    public class Foo
    {
        [Key]
        public int Id { get; set; }
    
        [Required]
        public int? BarId { get; set; }
    
        public virtual Bar Bar { get; set; }
    }
