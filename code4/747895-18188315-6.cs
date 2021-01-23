    public class ManufacturerViewModel
        {
            public Manufacturer Manufacturer { get; set; }
            public IList<CategoryViewModel> Categories { get; set; }
    
            public ManufacturerViewModel()
            {
                Categories = new List<CategoryViewModel>();
            }
        }
