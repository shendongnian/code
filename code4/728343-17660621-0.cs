    public ActionResult NewBooking()
    {
        var db = new VirtualTicketsDBEntities2();
        IEnumerable<SelectListItem> items = db.Attractions
          .Select(c => new SelectListItem
          {
              Value = SqlFunctions.StringConvert((double)c.A_ID)
              Text = c.Name
          });
        ViewBag.CategoryID = items;
        return View();
    }
