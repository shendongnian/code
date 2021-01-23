    [HttpPost]
    public ActionResult SubmitForm(MyViewModel model)
    {
        // Retrieve existing object
        var someObject = _context.Resources.OfType<MyEntityType>.Where
            (o => o.Id == model.Id).SingleOrDefault;
        // Assign new values to entity
        someObject.SomeProperty = model.SomeProperty;
        someObject.SomeOtherProperty = model.SomeOtherProperty;
        // Commit
        _context.SaveChanges();
    }
