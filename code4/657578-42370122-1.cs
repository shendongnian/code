    public class SomeController : Controller
    {
       [HttpGet]
       public Action SomeAction(string q)
       {
           // mvc will execute this action and pass
           // my default off to the next method
           return SomeAction(q, SomeDefaultFn);
       }
       public ActionResult SomeAction(string q, Func<string, SomeResultType> fn)
       {
            ...
            return View(...);
       }
    }
