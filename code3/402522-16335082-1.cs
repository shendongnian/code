    [HttpGet]
    public ActionResult Setname(int id)
    {
       ViewBag.Result = "You entered: " + id;
        return View();
    }
