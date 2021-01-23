    public class HomeController : Controller
    {
        // ViewBag & ViewData sample
        public ActionResult Index()
        {
            var featuredProduct = new Product
            {
                Name = "Special Cupcake Assortment!",
                Description = "Delectable vanilla and chocolate cupcakes",
                CreationDate = DateTime.Today,
                ExpirationDate = DateTime.Today.AddDays(7),
                ImageName = "cupcakes.jpg",
                Price = 5.99M,
                QtyOnHand = 12
            };
        
            ViewData["FeaturedProduct"] = featuredProduct;
            ViewBag.Product = featuredProduct;
            TempData["FeaturedProduct"] = featuredProduct;  
        
            return View();
        }
    }
