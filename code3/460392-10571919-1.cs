    public ActionResult SomeAction(SomeModel model) {
        if(ModelState.IsValid) {
            // do cool stuff with model data
        }
        var errorMessages = GetModelStateErrors(ModelState);
        foreach (var errorMessage in errors) {
            // do whatever you want with the error message string here
        }
    }
