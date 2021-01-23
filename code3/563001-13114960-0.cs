    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return 
                View(new List<BaseModel>() { new BarModel() { BaseProp = "Bar" }, new FooModel() { BaseProp = "Foo" } });
        }
        [HttpPost]
        public ActionResult Index(IList<BaseModel> model)
        {
            return this.View(model);
        }
    }
