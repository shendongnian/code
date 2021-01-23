    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new ProductModel 
            {
                ProductNo = "123",
                ProductName = "p name",
                Stocks = new[]
                {
                    new Stock { Key = "key1", Value = "value1" },
                    new Stock { Key = "key2", Value = "value2" },
                }
            };
            return View(model);
        }
      
        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
            ...
        }
    }
