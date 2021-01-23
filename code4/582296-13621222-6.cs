    public ActionResult Details1(int id, string LastName)
    {
       ViewBag.Id = id;
       ViewBag.LastName = LastName;
       return View();
    }
