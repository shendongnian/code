    [Authorize(Users = "ABC1, ABC2")]
    public class SomeController : Controller
    
    // Or
    [Authorize(Users = "ABC1, ABC2")]
    public ActionResult SomeAction()
