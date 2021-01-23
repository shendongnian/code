    public class HomeController : Controller
        {
            //
            // GET: /Home/
            public class Car
            {
                public int Id { get; set; }
                public string Colour { get; set; }
                public Category Category { get; set; }
            }
    
            public class Category
            {
                public int CatId { get; set; }
                public string Name { get; set; }
            }
    
            public ActionResult Index()
            {
                var car = new Car { Id = 1, Colour = "Black", Category = new Category { CatId = 2, Name = "Audi" } };
    
                return View(car);
            }
        }
