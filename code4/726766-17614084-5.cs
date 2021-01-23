    public class MyController : Controller
    {
         [HandleCustomError(Order = 5)]
         public ActionResult ActionMethod()
         {
             //Some code
         }   
    }
    
