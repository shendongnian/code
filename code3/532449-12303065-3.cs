    public class SomeController : BaseController {
      public ActionResult SomeAction(FormCollection collection) {
        if(ModelState.IsValid) {
          //Do something
          return SomeThingValidHappened();
        }
        //Not Valid
        PreserveModelState = true;
        return RedirectToAction("myAction");
      }
    }
