     public ActionResult Index()
     {
          HTMLMVCCalendar.Models.MonthModel someModel = new HTMLMVCCalendar.Models.MonthModel();
          someModel.DateTime = DateTime.Now; // whatever
          return View(someModel);
     }
