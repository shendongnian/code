        [HttpPost]
    public ActionResult PrintReport(Model m)
    {
        if (!Model.FromDate.HasValue || !Model.ToDate.HasValue)
            ModelState.AddModelError("Date", "At leaste one date is null");
        else {
            if (Model.FromDate.Value.CompareTo(Model.ToDate.Value) >= 0)
                ModelState.AddModelError("Date", "First date is later then the second one");
        }
        if(Model.IsAnythingChecked())
            ModelState.AddModelError("Checkboxes", "You haven't checked any checkboxes");
        if (ModelState.IsValid)
        {
            return View("PrintReport", Model);
        }
        else
        {
            return InternalIndex();
        }
    }   
