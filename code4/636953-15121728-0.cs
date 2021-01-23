    public class ControllerBase : Controller
    {
      public bool CheckSubmission(int id = 0)
      {
        Get Records from DB with criteria
        If Record available return true
        else return false
      }
    }
    public class SomethingController : ControllerBase
    {
        // Can use CheckSubmission in here
    }
