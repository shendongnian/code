    public class ValidationController : Controller
    { 
         public JsonResult UniqueUsername(ParentViewModel Registration) 
         {
            var Username = Registration.User.Username; //access the child view model property like so
            
            //Validate and return JsonResult
         }
    }
