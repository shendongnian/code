    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Facebook;
    namespace FacebookTest.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
                return View();
            }
            public ActionResult About()
            {
                ViewBag.Message = "Please log in first";
                if (Session["AccessToken"] != null)
                {
                    var accessToken = Session["AccessToken"].ToString();
                    var client = new FacebookClient(accessToken);
                    try
                    {
                        dynamic result = client.Get("me", new { fields = "name,id" });
                        string name = result.name;
                        string id = result.id;
                        ViewBag.Message = "Hello id: " + id + " aka " + name;
                    }
                    catch (FacebookOAuthException x)
                    {
                    
                    }
                }
                return View();
            }
            public void FacebookLogin(string uid, string accessToken)
            {
                var context = this.HttpContext;
                context.Session["AccessToken"] = accessToken;
            }
        }
    }
