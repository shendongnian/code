    [HttpPost]
    public ActionResult Index(string facebookUID, string facebookAccessTok)
    {
        string fbUID = facebookUID;
        string fbAcess = facebookAccessTok;
        var fullpath = "";
        string uploadPath = Server.MapPath("~/upload");
        fullpath = uploadPath + "\\ProfilePic.png";
        return RedirectToAction("Publish", "TheOtherController", new { fbAccess = fbAccess, fullpath = fullpath });
    }
    public class TheOtherController : Controller
    {
        public ActionResult Publish(string fbAccess, string fullpath)
        {
            // Do whatever you want
            //
        }
    }
