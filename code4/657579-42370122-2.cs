    public class SomeController : Controller
    { 
        [HttpGet]
        public ActionResult SomeAction(string q, string filterType)
        {
            return SomeAction(q, FilterFactory.Build(filterType));
        }
        
        ...
    }
