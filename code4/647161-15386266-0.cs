    public class ServerController : Controller
    {
     [HttpPost]
     public ActionResult ApplicationPoolsUpdate(ServiceViewModel viewModel)
     {
          XDocument updatedResultsDocument = myService.UpdateApplicationPools();
          ApplicationPoolController pool=new ApplicationPoolController(); //make an object of ApplicationPoolController class.
          return pool.UpdateConfirmation(updatedResultsDocument); // call the ActionMethod you want as a simple method and pass the model as an argument.
          // Redirect to ApplicationPool controller and pass
          // updatedResultsDocument to be used in UpdateConfirmation action method
     }
    }
