    [HttpPost]
    public ActionResult SomeAction(MyModel model)
    {
        var validator = new MyModelValidator();
    
        var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    warnings.Add(error.ErrorMessage);
    
    
        ...
       
    }
