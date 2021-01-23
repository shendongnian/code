    if (ModelState["InnerClass.Name"].Errors.Count > 0)
    {
        foreach (var error in ModelState["InnerClass.Name"].Errors)
        {
            message = error.ErrorMessage;
            isValidFlag = false;
        }
    }
