    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    
    namespace DribbbleR.Web.Controllers
    {
        public class HomeController : Controller
        {
            private static dynamic shots;
            private HttpClient client = new HttpClient();
            private string url = "http://api.dribbble.com/shots/everyone?per_page=30";
    
            public Task<dynamic> Index()
            {
                if (shots == null)
                {
                    shots = Task.Factory.StartNew(() =>
                    {
                        return DownloadContent();
    
                    }).Unwrap();    
                }
    
                return shots;
            }
    
            public Task<dynamic> DownloadContent()
            {
                var responseTask = client.GetAsync(url);
    
                var readTask = responseTask.ContinueWith(t =>
                {
                    t.Result.EnsureSuccessStatusCode();
    
                    return t.Result.Content.ReadAsStringAsync();
                })
                .Unwrap();
    
                var deserializeTask = readTask.ContinueWith(t =>
                {
                    return JsonConvert.DeserializeObjectAsync<dynamic>(t.Result);
                })
                .Unwrap();
    
                var viewTask = deserializeTask.ContinueWith(t =>
                {
                    return this.View(t.Result);
                });
    
                return viewTask;
            }
    
        }
    }
