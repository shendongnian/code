    public ActionResult ChangeRiskCategory(Guid id)
    {
        //...
        //call server side method,  handle errors
        //...
        ModelState.AddModelError("MyInput","This isn't Right");
        return View("ChangeRiskCategory", changeRiskCategoryModel);
     }
