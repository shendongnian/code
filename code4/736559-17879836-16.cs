    public class HomeController : Controller
    {
        [HandleForbiddenRedirect]
        public ActionResult Edit(int idObject)
        {
             //...
        }
    }
