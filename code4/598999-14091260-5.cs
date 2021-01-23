    public class AccountController: Controller
    {
        public ActionResult AddToCartHack(string url)
        {
            GeneralHelperClass.URL = url;
            return Json(new { success = true });
        }
    }
