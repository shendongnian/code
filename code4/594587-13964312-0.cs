    public class HomeIndexViewModel
    {
        public Image ForSale { get; set; }
        public Image Sold { get; set; }
        public Image PrivateCollection { get; set; }
        // Default constructor
        public HomeIndexViewModel()
        {
           ForSale = new Image();
           Sold = new Image();
           PrivateCollection = new Image();
        }
        public class Image
        {
           public string ImageUrl { get; set; }
           public string ImageDescription { get; set; }
        }
    }
