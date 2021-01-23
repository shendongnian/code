    public class MyController : Controller 
    {
        private OldController old = new OldController();
        // OldController method we want to "override"
        public ActionResult Product(int productid)
        {
            ...
            return View(...);
        }
    
        // Other OldController method for which we want the "inherited" behavior
        public ActionResult Method1(...)
        {
            return old.Method1(...);
        }
    }
