    [HttpPost] // can be HttpGet
    public ActionResult Test(string id)
    {
         bool isValid = yourcheckmethod(); //.. check
         var obj = new {
              valid = isValid
         };
         return Json(obj);
    }
