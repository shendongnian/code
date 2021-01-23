    public class TestingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            var file = Request.Files[0];
            var filename = Request.Form["filename"];
            var uri = string.Format("http://yoururl/serviceRoute/{0}", filename);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("image/pjpeg"));
            var content = new StreamContent(file.InputStream);
            var response = client.PostAsync(uri, content);
            ViewBag.ServerUri = uri;
            ViewBag.StatusCode = response.Result.StatusCode.ToString();
            return View();
        }
    }
