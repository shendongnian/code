     [HttpPost]
     public ActionResult Index(HTMLMVCCalendar.Models.MonthModel previousModel, bool? goForward)
     {
          if(goForward.HasValue && goForward.Value)
                previousModel.DateTime = previousModel.DateTime.AddMonths(1);
          else
                previousModel.DateTime = previousModel.DateTime.AddMonths(-1);
          return View(previousModel);
     }
