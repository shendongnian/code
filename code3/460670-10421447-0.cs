    var items = new List<SelectListItem>()
    {
       new SelectListItem { Value = "", Text = "00" }
    }
    
    ViewBag.AccountIdList = new SelectList(items);
