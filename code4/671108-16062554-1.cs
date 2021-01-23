    public class MyEntity
    {
        [Key]
        public int Id { get; set; }
        public int? Value { get; set; } // this is now nullable
    }
