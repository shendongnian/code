    for (int i = 0; i < model.FreeFields.Count(); i++)
    {
        //Generate the expression for the item
        Expression<Func<CreateFieldsModel, string>> expression = x => x.FreeFields[i].Value;
        //Get the name of our html input item
        string key = ExpressionHelper.GetExpressionText(expression);
        //Add an error message to that item
        ModelState.AddModelError(key, "Error!");
    }
    if (!ModelState.IsValid)
    {
        return View(model);
    }
