    public class CarFormModel // this is a "model class" and not your entity
    {
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public int BrandId { get; set; }
        //replacement for your ViewBag.BrandSelect
        //you can also create a viewmodel for this
        //but let's use your entity for a more simple example
        public IEnumerable<Brand> Brands {get;set;}
    }
