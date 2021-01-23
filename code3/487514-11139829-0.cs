    public class ApiController : Controller {
    
        public ActionResult CallSomething() {
             MyActionFilter.CommonStaticMethodThatIsAlsoUsedInTheNormalFilter();
             return IsCalled();
        }
    
        [MyActionFilter]
        public ActionResult IsCalled() {
             return View();
        }
    }
