    public ActionResult Error(string ex, string message)
    {
        var error = (string)TempData["Error"];
        // do other magic ...
    }
