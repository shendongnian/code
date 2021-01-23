    [HttpPost]
    public ActionResult EmailRequest(EmailRequest model)
    {
        if (ModelState.IsValid)
        {
            // save to db, for instance
            return RedirectToAction("AnotherAction");
        }
        return View();
    }
