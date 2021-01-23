    public class JsonErrorModel
    {
        public int ErrorCode { get; set;}
    
        public string ErrorMessage { get; set; }
    }
    public ActionResult SomeMethod()
    {
        var error = new JsonErrorModel
        {
            ErrorCode = -1,
            ErrorMessage = "Something really bad happened"
        };
        return Json(error);
    }
