    public ActionResult Profile(int id)
    {
        if (CurrentUser.Id != id)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
