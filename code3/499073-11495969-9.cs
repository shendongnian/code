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
            public ActionResult FacebookLoginNoJs()
            {
                return Redirect("https://www.facebook.com/dialog/oauth?client_id=MY-APPID-REMOVED&redirect_uri=http://localhost:45400/Home/ConnectResponse&state=secret");
            }
            public ActionResult ConnectResponse(string state, string code, string error, string error_reason, string error_description, string access_token, string expires)
            {
                if (string.IsNullOrEmpty(error))
                {
                    try
                    {
                        var client = new FacebookClient();
                        dynamic result = client.Post("oauth/access_token",
                                                  new
                                                  {
                                                      client_id = "MY-APPID-REMOVED",
                                                      client_secret = "MY-APP-SECRET-REMOVED",
                                                      redirect_uri = "http://localhost:45400/Home/ConnectResponse",
                                                      code = code
                                                  });
                        Session["AccessToken"] = result.access_token;
                        if (result.ContainsKey("expires"))
                            Session["ExpiresIn"] = DateTime.Now.AddSeconds(result.expires);
                    }
                    catch
                    {
                        // handle errors
                    }
                }
                else
                {
                   // Declined, check error
                }
                return RedirectToAction("Index");
            }
        }
    }
