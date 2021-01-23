    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Web; 
    using System.Web.Mvc; 
    using MVCTest1.Models ; 
     
    namespace MVCTest1.Controllers 
    { 
        public class HomeController : Controller 
        { 
            public ActionResult Index() 
            { 
                ViewBag.Message = "Welcome to ASP.NET MVC!"; 
     
                return View(); 
            } 
            [HttpPost]
            public ActionResult Index(EnteredTextModel theModel) 
            { 
                return View(theModel); 
            } 
     
            public ActionResult About() 
            { 
                return View(); 
            } 
     
        } 
    } 
