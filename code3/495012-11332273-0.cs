    [HttpPost]
    public void FtpAsync(Downloads model)
    {
        ...
    }
    public ActionResult FtpCompleted(Downloads model)
    {
        return Content("Complete");
    }    
