    [HttpPost]
    public ActionResult Edit(MyItemViewModel vm)
    {
        // Get the domain model that we want to update
        MyItem item = Repository.GetItem(vm.Id);
    
        // Merge the properties of the domain model from the view model =>
        // update only those that were present in the view model
        Mapper.Map<MyItemViewModel, MyItem>(vm, item);
    
        // At this stage the item instance contains update properties
        // for those that were present in the view model and all other
        // stay untouched. Now we could persist the changes
        Repository.Update(item);
    
        return RedirectToAction("Success");
    }
