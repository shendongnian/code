    public class PropertyViewModel
    {
        public int Id { get; set; }
        [Required]
        public PropertyType PropertyType { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public StateFullName State { get; set; }
        [Required]
        public string Zip { get; set; }
    }
