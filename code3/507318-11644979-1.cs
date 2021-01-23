    public class AccountController : Controller
    {
        public ActionResult CheckPassword(string password)
        {
            bool passwordIsCorrect = //do your checking;
            string returnString = "whatever message you want to send back";
            return Content(returnString);
        }
    }
