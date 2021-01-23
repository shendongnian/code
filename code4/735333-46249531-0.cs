     namespace Name
        {
                public class Hub
            {
                public string Mode { get; set; }
    
                public string Challenge { get; set; }
    
                // ReSharper disable once InconsistentNaming
                public string Verify_Token { get; set; }
            }
    
            public class FacebookWebHooksController : Controller
            {
                [System.Web.Http.HttpGet, ActionName("Callback")]
                [AllowAnonymous]
                public ContentResult CallbackGet(Hub hub)
                {
                    if (hub.Mode == "subscribe" && hub.Verify_Token == "YOUR_TOKEN")
                        return Content(hub.Challenge, "text/plain", Encoding.UTF8);
    
                    return Content(string.Empty, "text/plain", Encoding.UTF8);
                }
            }
    
            [HttpPost]
            [AllowAnonymous]
            public ActionResult Callback()
            {
                Request.InputStream.Seek(0, SeekOrigin.Begin);
                var jsonData = new StreamReader(Request.InputStream).ReadToEnd();
    
            }
        }
