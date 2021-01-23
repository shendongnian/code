    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Mvc;
    using Demo.Models;
    namespace Demo.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                HttpClient client = new HttpClient();
                Task<IEnumerable<Tweet>> tweetTask = client.GetStringAsync("http://search.twitter.com/search.json?q=dave")
                    .ContinueWith(stringTask =>
                        {
                            return JsonConvert.Deserialize<IEnumerable<Tweet>>(stringTask.Result);
                        }
                return View(tweetTask.Result);
         }
    }
