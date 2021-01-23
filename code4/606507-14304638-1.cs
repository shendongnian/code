    public ActionResult Edit(int id)
    {
        var model = new MyViewModel();
        using (var db = new SomeDataContext())
        {
            // Get the boxer you would like to edit from the database
            model.Boxer = db.Boxers.Single(x => x.BoxerId == id);
            // Here you are selecting all the available weight categroies
            // from the database and projecting them to the IEnumerable<SelectListItem>
            model.WeightCategories = db.WeightCategories.ToList().Select(x => new SelectListItem
            {
                Value = x.WeightCategoryId.ToString(),
                Text = x.Name
            })
        }
        return View(model);
    }
