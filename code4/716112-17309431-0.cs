    public abstract class MyControllerBase : Controller
    {
      // whatever parameters
      protected SharedModel GetSharedModel()
      {
        // do logic
        // return model
      }
    }
    public class OneController : MyControllerBase
    {
      protected ActionResult Index()
      {
        var model = this.GetSharedModel()
        return this.View(model);
      }
    }
    public class TwoController : MyControllerBase
    {
      protected ActionResult Index()
      {
        var model = this.GetSharedModel()
        return this.View(model);
      }
    }
