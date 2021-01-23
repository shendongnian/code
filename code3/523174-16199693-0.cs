    [HttpPost]
    public ActionResult Drop(SelectListItem item)
    {
    
        var selectedValue = Request.Form["ID_OF_THE_DROPDOWNLIST"];
        //TODO......
        return RedirectToAction("Drop");
    }
