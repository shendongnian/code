    public ActionResult lettingselect()
    {
         var model = _db.EstateAgents;
        DropList rlist = new DropList();
        List<SelectListItem> listItems = new List<SelectListItem>();
        foreach (var item in model)
        {
            listItems.Add(new SelectListItem()
            {
                Value = item.estateAgentID.ToString(),
                Text = item.CompanyName
            });
        }
        ViewData["List"] = listItems;
        return View(rlist);
     }
