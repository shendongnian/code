    public class CategoryController
    {
       private readonly ICategoryService _categoryService;
    
       // inject by constructor..
       public CategoryController(ICategoryService categoryService)
       {
           _categoryService = categoryService;
       }
    
    
       public ActionResult Index()
       {
          var categories = _categoryService.GetCategory();
    
          return View(categories);
       }
    
    }
