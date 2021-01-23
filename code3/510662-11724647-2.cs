    public ActionResult SomeAction()
    {
        Dictionary<string, string> values = ......
        var model = new MyViewModel();
        model.SelectedValue = (string)TempData["name"]; 
        model.Values = values.Select(x => new SelectListItem
        {
            Value = x.Key,
            Text = string.Format("{0} {1}", x.Key, x.Value)
        });
    
        return View(model);
    }
