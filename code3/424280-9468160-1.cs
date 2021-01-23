    public ActionResult Index()
    {
        Summit[] summit = new Summit[10];
        for (int index = 0; index < summit.Length; index++)
        {
            summit[index] = new Summit();
        }
        summit[0].Height = 1;
        summit[0].Name = "himan";
        return View(summit.AsEnumerable());
    }
