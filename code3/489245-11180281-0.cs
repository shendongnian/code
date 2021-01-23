    ///
    /// Displays form to edit model
    ///
    public ActionResult Edit(int id)
    {
        MyModelClass m = new MyModelClass();
        return View(m);
    }
    [HttpPost]
    public ActionResult Edit(MyModelClass m)
    {
        if( !ModelState.IsValid )
        {
            // Got error, return view
            return View(m);
        }
        return RedirectToAction("/mymodel/success");
    }
