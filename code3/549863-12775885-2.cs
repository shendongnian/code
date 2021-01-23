    public ActionResult Create(MessageVM message) 
    {
        if (!ModelState.IsValid)
        {
            return View(message);
        }
        //else do whatever you need, send the email etc.
    }
