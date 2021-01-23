    public class Dog
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Empty dog name")]
        [MaxLength(10,ErrorMessage="Up to 10 chars")]
        [Display(Name="Dogs name")]
        public string Name { get; set; }
        public int ownerID { get; set; }
    }
