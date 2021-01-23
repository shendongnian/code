    public ActionResult NewBooking()
    {
        var db = new VirtualTicketsDBEntities2();
        IEnumerable<SelectListItem> items = db.Attractions.AsEnumerable()
          .Select(c => new SelectListItem
          {
              Value = c.A_ID.ToString()
              Text = c.Name
          });
        ViewBag.CategoryID = items;
        return View();
    }
