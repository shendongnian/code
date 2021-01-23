    public IActionResult About([FromServices] IDateTime dateTime)
    {
        ViewData["Message"] = "Currently on the server the time is " + dateTime.Now;
        return View();
    }
