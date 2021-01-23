    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(string email)
        {
            // The default model binder will set the value of the `email` parameter to the 
            // value of the matching input from your form
            /* Do cool stuff because you can */
        }
    }
