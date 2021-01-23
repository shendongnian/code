    var selections = new List<string> { "ScienceFiction", "fantasy", "LoveStory", "History" };
    ViewBag.category = selections
        .Select(s => new SelectListItem
                     {
                         Text = s,
                         Value = s,
                         Selected = s == author.Category
                     })
        .ToList();
