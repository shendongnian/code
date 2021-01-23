    public class SomeController : Controller
    {
        [IsLocal]
        public ActionResult LocalOnlyMethod()
        {
            return View();
        }
    }
