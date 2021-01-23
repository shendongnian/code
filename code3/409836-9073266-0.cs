    return RedirectToAction("Message", err);
    return RedirectToAction("Message", rcpt);
    
    public ActionResult Message(ContactModel model)
    {
        return View(model);
    }
