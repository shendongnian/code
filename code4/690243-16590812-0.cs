    public class ItemController : Controller
    {
      public ActionResult List()
      {
        //fetch from db
        return View(yourViewModel);
      }
    
      public ActionResult Details(int id)
      {
        //fetch one item using the id
        return View(theItemViewModel);
      }
    }
