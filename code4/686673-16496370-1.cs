    public class PackageModel
    {
        public IEnumerable<SelectListItem> Allcategories { get; set; }
    
        public PackageModel()
        {
           Allcategories = new IEnumerable<SelectListItem>();
           /* Add values  to Allcategories here */
        }
    }
