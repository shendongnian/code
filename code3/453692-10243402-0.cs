    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.Collections.Generic;
    
    
    namespace TestArea.Controllers
    {
        [Authorize]
        public class MyFirstController : Controller
        {
            
            public ActionResult Index()
            {
                return View();
            }
    
            public ActionResult SeeYourDetails() 
            {
                //get the currently logged in user
                var current = Membership.GetUser();
                //you can always do something else here
                return View(current);
            }
    
            
        }
