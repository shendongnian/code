    public async Task JsonResult BookThing(InputModel model)
    {
        // Do some stuff
        thisIsAnAsyncMethod(Model model); // Fire and forget
        return Json(null);
    }
    
    protected async Task thisIsAnAsyncMethod(Model model)
    {
        await oneThing();
        await anotherThing();
        await somethingElse();
    }
