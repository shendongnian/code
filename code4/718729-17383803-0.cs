    public class AccountController : Controller
    {
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial", (Session["Login"] as LoginModel) ?? new LoginModel());
        }
        [HttpPost]
        public HttpStatusCodeResult SaveLoginModel(LoginModel model)
        {
            Session["Login"] = model;
            return new HttpStatusCodeResult(200);
        }
    }
