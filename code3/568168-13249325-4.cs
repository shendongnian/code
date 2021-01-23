    [HttpPost, ActionName("ListOfUsers")]
    public ActionResult ListOfUsersPost(ListOfUsersViewModel model)
    {
        // at this point, model will be instantiated, complete with UsersOfList with values submitted by the user
    
        if (ModelState.IsValid) // check to see if any users are missing required fields. if not...
        {
             // save the submitted changes, then redirect to a success page or whatever, like I do below
            return RedirectToAction("UsersUpdated");
        }
    
        // if ModelState.IsValid is false, a required field or other validation failed. Just return the model and reuse the ListOfUsers view. Doing this will keep the values the user submitted, but also include the validation error messages so they can correct their errors and try submitting again
        return View("ListOfUsers", model);
    
    }
