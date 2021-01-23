    public ActionResult ChangeRiskCategory(Guid id, bool error = false)
    {
        //...
        //call server side method,  handle errors
        //...
        if (!error && !ModelState.IsValid /*or other way of working out the error will be displayed*/)
        {
            return Redirect(Url.Action("ChangeRiskCategory") + "?id=" + id + "&error=true#server_error");
        }
        return View("ChangeRiskCategory", changeRiskCategoryModel);
    
    }
