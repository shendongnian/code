    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage="* required")]
        [Display(Name="Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Description")]
        public string CategoryDescription { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
