    public async Task<ActionResult> Login(LoginModel model)
    {
    //
    //You would do some async work here like I was doing.
    //
    return RedirectToAction("Action","Controller");//The action must be async as well
    }
    public async Task<ActionResult> Action()//This must be an async task 
    {
    return View();
    }
