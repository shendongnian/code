    [HttpPost]
    public ActionResult Edit(CustomerViewModel model)
    {
       foreach(var opt in model.OptionList)
       {
          //check for model.IsSelected value for each item
       }
    }
