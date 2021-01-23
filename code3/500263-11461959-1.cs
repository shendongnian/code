    [Authorize]
    public class HomeController : Controller
    [Authorize(Roles = "Recruiter")]
    public ActionResult MethodOne()
    {
    }
