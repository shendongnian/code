    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Mvc;
    using Newtonsoft.Json.Linq;
    using PayPoint.Models;
    using System.Threading.Tasks;
    
    namespace PayPoint.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                var model = new List<Tweets>();
                const string webUri = "http://search.twitter.com/search.json?q=dave";
    
                var client = new HttpClient();
                var tweetTask = client.GetAsync(webUri);
                Task<JObject> jsonTask = tweetTask.Result.Content.ReadAsAsync<JObject>();
                var results = jsonTask.Result;
    
                model.AddRange((from b in results["results"]
                         select new Tweets()
                             {
                                 Name = b["from_user"].ToString(),
                                 Text = b["text"].ToString()
                             }).ToList());
    
                return View(model);
            }
        }
    }
