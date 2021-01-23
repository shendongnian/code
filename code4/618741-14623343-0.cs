    public class FooState
    {
        [Required]
        [Key]
        [ForeignKey("Foo")]
        public int FooStateId { get; set; }
        [Required]
        public int State { get; set; }
        public Foo Foo { get; set; }
    }
