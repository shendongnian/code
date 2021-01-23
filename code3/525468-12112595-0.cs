    public ActionResult TestError(string id) // id = error code
    {
        Response.StatusCode = 400; // Replace .AddHeader
        var error = new Error();
        error.ErrorID = 123;
        error.Level = 2;
        error.Message = "You broke the Internet!";
        return Json(error, JsonRequestBehavior.AllowGet);
    }
