    public class SomeController : Controller
    {
        [IsLocal(ThrowSecurityException = true)]
        public ActionResult LocalOnlyMethod()
        {
            return View();
        }
    }
