    public ActionResult MyForm()
    {
        SearchViewModel model =
            new SearchViewModel()
            {
                Distance = 5 // This is the item that will be selected.
            };
        return View(model);
    }
