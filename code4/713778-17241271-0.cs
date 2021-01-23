    if(itemID == null)
    {
        ViewData["ErrorMessage"] = "The ID provided provoked an error. Please try again. If the problem persist, contact your local administrator.";
        return View(); // you probably have a model to include as well
    }
    else
    {
        // perform your action
        return RedirectToAction("some action");
    }
