    [Authorize(Roles = "Admin, Customer")]
    public class ProductController : Controller
    {
        public ActionResult Info()
        {
            //get product information here
    
            ProductViewModel pvm = new pvm();
    
            return View(pvm);
        }
    [Authorize(Roles = "Admin")]
    public ActionResult EditInfo()
        {
            //get product information here
        
            EditProductViewModel epvm = new epvm();
        
            return View(epvm);
        }
    }
