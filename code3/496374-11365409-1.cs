    public async Task<ActionResult> IndexAsync()
    {
        var waiter = new Waiter();
        int result = await waiter.GetValue();
        // it never gets here 
        return View();
    }
