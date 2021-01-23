    public class SomeController : Controller
    {
        [HttpGet]
        public ActionResult SomeAction(string q, Func<string, SomeResultType> fn = null) 
        {
            fn = fn ?? SomeDefaultFn;
            ...
            return View(...);
        }
    }
