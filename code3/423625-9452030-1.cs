    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(string image)
        {
            image = image.Substring("data:image/png;base64,".Length);
            var buffer = Convert.FromBase64String(image);
            // TODO: I am saving the image on the hard disk but
            // you could do whatever processing you want with it
            System.IO.File.WriteAllBytes(Server.MapPath("~/app_data/capture.png"), buffer);
            return Json(new { success = true });
        }
    }
