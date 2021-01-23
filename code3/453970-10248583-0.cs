    public ActionResult PrintReport(Model m)
    {
        if (!m.FromDate.HasValue || !m.ToDate.HasValue)
            ModelState.AddModelError("Date", "At leaste one date is null");
        else {
            if (m.FromDate.Value.CompareTo(m.ToDate.Value) >= 0)
                ModelState.AddModelError("Date", "First date is later then the second one");
        }
        if(m.IsAnythingChecked())
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
