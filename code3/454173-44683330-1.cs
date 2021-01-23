    public class HomeController : Controller  
    {  
        public ActionResult Index()  
        {  
            ViewBag.TempValue = "Index Action called at HomeController";  
            return View();  
        }  
       
        [ChildActionOnly]  
        public ActionResult ChildAction(string param)  
        {  
            ViewBag.Message = "Child Action called. " + param;  
            return View();  
        }  
    }  
