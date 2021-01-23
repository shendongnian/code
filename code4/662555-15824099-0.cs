    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        public ActionResult Info()
        {
            //get product information here
    
            ProductViewModel pvm = new pvm();
            pvm.Product = theProduct;
            pvm.IsAdmin = checkAdminAccess(); //This would return a bool if they had access
            pvm.IsSuperAdmin = checkSuperAdminAccess();//This would return a bool if they had access
    
            return View(pvm);
        }
    }
