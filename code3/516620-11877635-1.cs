    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace MvcApplication1.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult Index(List<Ingredient> MyModelArray) //Put a breakpoint here to see 
            {
                return View();
            }
            [HttpPost]
            public ActionResult About(List<string> MyStringArray) //Use this if you don't want a model
            {
                return View();
            }
        }
        public class Ingredient
        {
            public string Sugar { get; set; }
            public string Tea { get; set; }
        }
    }
