    public ActionResult _Header() {
      DateSearchViewModel DateVM = new DateSearchViewModel();
      return View(DateVM);
    }
    public ActionResult _Header( DateSearchViewModel vm ) {
      if( ModelState.IsValid ) {
        // save vm to database, etc.
      }
      return View(vm);
    }
