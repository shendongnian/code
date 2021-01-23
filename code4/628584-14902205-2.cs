    public async Task<ActionResult> Login(LoginModel model) {
        return RedirectToAction("Action","Controller");
        // The called action must be async as well
    }
    // This must be an async task 
    public async Task<ActionResult> Action() {
        return View();
    }
