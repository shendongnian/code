    public ActionResult AddBook()
    {
        var model = new MyViewModel();
        model.Categories = categoryContext.GetCategories();
        model.Book = ...
        return View(model);
    }
    [HttpPost]
    public ActionResult AddBook(MyViewModel model)
    {
        bookContext.AddBook(model.Book);
        return RedirectToAction("Index", "ProductManager");
    }
