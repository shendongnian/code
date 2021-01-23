    var items = new List<string>();
    if (Model.Views > 0)
        items.Add(string.Format("{0:n0} {1}", Model.Views, _views));
    if (Model.Comments > 0)
        items.Add(string.Format("{0:n0} {1}", Model.Comments, _comments));
    var result = ", ".Join(items);
