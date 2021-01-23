    public class ErrorsController : Controller
    {
        /// <summary>
        /// Page not found
        /// </summary>
        /// <returns></returns>
        public ActionResult Http404()
        {
            return View();
        }
        /// <summary>
        /// All other errors
        /// </summary>
        /// <param name="actionName"></param>
        protected override void HandleUnknownAction(string actionName)
        {
            // in case detailed exception is required.
            var ex = (Exception) RouteData.Values["ex"];
            return View();
        }
    }
