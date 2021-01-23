    public class WallController : Controller
    {
     public ActionResult Details(string type ,long id, string name)//added param
     {
        return View(LoadWallData(id));
     }
     }
