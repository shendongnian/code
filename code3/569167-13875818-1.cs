    public class LoginFormController : Controller
    {
        public ActionResult ShowLogin()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult EnterLogin(FormCollection collection)
        {
            string Yourtxtname=Collection["txtName"]; //You will get input text value
            
            return View();
        }
    }
