    public class ItemController : Controller
    {
      public ActionResult List()
      {
        //fetch from db
        return View(yourViewModel);
      }
      [HttpPost]
      public ActionResult List(string firstLilPig, int secondLilPig, string thirdLilPig)
      {
        //fetch from db using the little pigs as filters
        return View(yourViewModel);
      }
    
      public ActionResult Details(int id)
      {
        //fetch one item using the id
        return View(theItemViewModel);
      }
    }
