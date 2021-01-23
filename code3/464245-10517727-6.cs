    string errorMessage;
    if (!Repository.TryUpdate(product, out errorMessage))
    {
        // the business validation failed => add the error message to the modelstate
        // and redisplay the view
        ModelState.AddModelError("", errorMessage);
        return View(viewModel);
    }
