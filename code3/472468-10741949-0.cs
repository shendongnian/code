    public ActionResult Edit(int id) {
        var entity = new Entity(id); // have a constructor in your entity that will populate itself and return the instance of what is in the db
        // map entity to ViewModel using whatever means you use
        var model = new YourViewModel();
        return View(model);
    }
