     [NoCache]
    public class WebPageController : Controller
    {
        public JsonResult JsonError(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException("exception");
            Response.StatusCode = 500;
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    error = true,
                    success = false,
                    message = exception.Message,
                    detail = exception.ToString()
                }
            };
        }
