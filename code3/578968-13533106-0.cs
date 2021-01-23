    public class Customer : Party
    {
        [Key]
        public int CustomID { get; set; }
    
        [Range(1, int.MaxValue)]
        public int ID { get; set; }
    }
