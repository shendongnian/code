    public ActionResult Index()
    {
        Summit[] summit = new Summit[10];
        summit[0].Height = 1;
        summit[0].Name = "himan";
        return View(summit);
    }
