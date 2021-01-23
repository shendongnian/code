    public JsonResult Step1()
    {
        return Json(new { Result = "Working", Message = "Waiting on Server" });
    }
    public JsonResult Step2()
    {
        return Json(new { Result = "Working", Message = "Crunching data" });
    }
    public JsonResult Step3()
    {
        return Json(new { Result = "Ok", Message = "Done" });
    }
