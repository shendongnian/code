    public class CustomersController : Controller
    {
      public ActionResult Details(int id)
      {
        CustomerViewModel objCustomer=new CustomerViewModel;
        objCustomer.FirstName="Samuel";
        //Instead of hardcoding the values here , you can get it
       // from the database using the id and assign to the properties
        return View(objCustomer);
      }
    
    
    }
