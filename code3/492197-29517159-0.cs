         public class HomeController : Controller
            {
                public ActionResult Index()
                {
                    //restore WebSecurity  connection
                    if (!WebSecurity.Initialized)
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        
                    ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
        
                    return View();
                }
    .......
