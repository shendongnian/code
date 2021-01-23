    public ActionResult About()
    {
      string test1;   // Declare a variable
      test1 = "A";    // Do something meaningless with it
      return View();  // Don't use it, so throw away the two previous statements
    }
