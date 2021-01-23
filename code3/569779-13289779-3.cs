    public class LoginController : Controller // Inherit from Controller base class.
    {
        // An action on the controller that you can call.
        [HttpPost] // Use HttpPost to limit only to POST requests.
        public ActionResult Test()
        {
            // Use your class here to get values.
            string value = LoginClass.test();
            // Return a content result that allows to return only text.
            return Content(value);
        }
    }
