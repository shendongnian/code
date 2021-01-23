    public class WallController : Controller
    {
         public ActionResult Details(long id, string name, string obj)//added param
         {
    
            return View(LoadWallData(id));
         }
    }
