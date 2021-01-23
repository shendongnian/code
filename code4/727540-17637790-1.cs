    public ActionResult Show(Int32 id)
    {
         // assuming you changed your DAL/Repository accordingly
         var guestEvent = dataSource.GetUserEventById(id, Session["userID"] as Int32);
         // or.., assuming your DAL/Repository exposes IQueryable
         var guestEvent = dataSource<GuestEventModel>
                              .Where(x => x.UserId == Session["userID"] as Int32)
                              .Single(x => x.Id == id);
         // ....
         return View(eventViewModel);
    }
