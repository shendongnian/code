    [Authorize]
    public class SettingsController : Controller
    {
        // ... skipping other constructor and method code
        [Authorize]
        [HttpPost]
        public ActionResult SetLanguage(MyLanguageModel model)
        {
            HttpCookie myCookie = new HttpCookie("UserSettings");
            myCookie.Value = model.AssignedLanguage;
            myCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(myCookie);
            return View(model);
        }
    }
