    // Retrieve the error messages as a list of strings.
    List<string> errorMessages = new List<string>();
    foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
    {
        string entityName = validationResult.Entry.Entity.GetType().Name;
        foreach (DbValidationError error in validationResult.ValidationErrors)
        {
            errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
        }
    }
