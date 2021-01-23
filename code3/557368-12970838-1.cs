    public ActionResult Delete(DeleteModel model)
    {
        .... Perform the delete ...
        return PartialView("AllItems", new AllItemsModel());
    }
