    [HttpPost]
    public ActionResult MyPostAction(Model1 item)
    {
      //do some verification here
      if ( ModelState.IsValid )
      {
        //save your Model1 data
        foreach( SubModel1 subitem in item.SubItems )
        {
          //Save your SubItems here
        }
      }
      return RedirectToAction("Index");
    }
