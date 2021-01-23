    public ActionResult FilterData(string redirectUrl = null)
    {
        // Do some work
        // ....
        if (redirectUrl != null) {
            return new RedirectResult(redirectUrl);
        }
        return View("Default");
    }
