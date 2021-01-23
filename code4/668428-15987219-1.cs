    [Authorize]
    public class HomeController : Controller
    {
        // All actions will require authorization
    }
    
    public class ImageController : Controller
    {
        public ActionResult PublicImage()
        {
        }
    
        [Authorize]
        public ActionResult ImageRequiringAuth()
        {
        }
    }
