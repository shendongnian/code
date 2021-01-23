    [HttpGet]
    public ActionResult EditAuthor(int id)
    {
        var db = new AuthorDatacontext();
        var selections = new List<string> { "ScienceFiction", "fantasy", "LoveStory", "History" };
        var model = new AuthorViewModel();
        model.Author = db.Authors.Find(id);
        model.Categories = selections
        .Select(s => new SelectListItem
                     {
                         Text = s,
                         Value = s,
                         Selected = s == model.Author.Category
                     })
        .ToList();
        return View(model);
    }
