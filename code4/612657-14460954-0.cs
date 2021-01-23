    public class FunctionsController : Controller
    {
        public ActionResult CallTargetFunction()
        {
            return Content(TargetFunction());
        }
    }
