    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public int BrandId { get; set; }
        public Brand Brand{ get; set; }
    }
