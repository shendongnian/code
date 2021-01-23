    // Delete action of the child item
    public ActionResult Delete(int id, FormCollection collection)
    {
        var parent_id = queryTheParentObjectId();
        DeleteChildFromDB(id);
        return RedirectToAction("ParentAction", new { controller = "ParentController", id = parent_id });
    }
