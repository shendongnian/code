    [HttpPost]
    public ActionResult action( DetailModel vm )
    {
     if (ModelState.IsValid)
     {
      foreach( var min in vm.MinistryRef )
      {
       switch( min.AccessRights )
       {
        case 0: /* Viewer */
        case 1: /* Updater */
        case 2: /* Minadmin */
       }
      }
     }
     return RedirectToAction("SomeHttpGet");
    }
