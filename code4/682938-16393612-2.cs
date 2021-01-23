    [HttpPost]
    public ActionResult Edit(EditCatDetailsViewModel model)
    {
        Debug.WriteLine("Cat Id: " + model.catId); //displays correct Id for Cat!!!
    }
