    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            var model = new CategoriesModel();
            model.CategoryNames = GetCategoryNames();
            return View(model);
        }
        private List<CategoryName> GetCategoryNames()
        {
            // TODO: you could obviously fetch your categories from your DAL
            // instead of hardcoding them as shown in this example
            var categories = new List<CategoryName>();
            categories.Add(new CategoryName { Id = 1, Name = "category 1" });
            categories.Add(new CategoryName { Id = 2, Name = "category 2" });
            categories.Add(new CategoryName { Id = 3, Name = "category 3" });
            return categories;
        }
    }
