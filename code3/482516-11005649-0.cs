       // you need to adjust your dependency accordingly
       Interface IRepository<T> : where t has a value
       {
         void Set(T item);
         T Get(some value that you indicate in T);
       }
    
        namespace mvc1.Controllers
        {
            public class HomeController : Controller
            {
                IRepository<SomeObject> _repo;
    
                public HomeController(IRepository<SomeObject> repository)
                {
                   _repo = repository;
                }             
    
        
                //
                // GET: /Home/
                public ActionResult Index(string search = "")
                {
                    ViewBag.Title = "You searched for: " + search;
        
                    using (SomeObject obj = _repo.get("tv_show?name=" + search))
                    {
                        // here you can use automapper to map a DTO or VO to View model.
                        FooViewModel model = someobject;
                        return View(model);
                    }
                }
        
            }
        }
