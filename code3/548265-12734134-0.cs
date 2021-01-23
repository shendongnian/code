    // POST: /Account/Signed
    [HttpPost]
    public ActionResult Signed(Customer customer)
    {
        try
        {
            //Stuff is here
            return RedirectToAction("Index", "Home");
        }
        catch
        {
            return RedirectToAction("Registration");
        }
    }
