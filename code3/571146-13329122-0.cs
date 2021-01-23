    public ActionResult Edit(int id)
    {
        Property property = db.Properties.Find(id);
        ViewBag.PropertyStatusList = SetViewBagPropertyStatus(property.PropertyStatus);
        return View(property);
    }
    private IEnumerable<SelectListItem> SetViewBagPropertyStatus(string selectedValue = "")
    {
        IEnumerable<ePropStatus> values = 
            Enum.GetValues(typeof(ePropStatus)).Cast<ePropStatus>();
            IEnumerable<SelectListItem> items =
             from value in values
             select new SelectListItem
             {
                 Text = value.ToString(),
                 Value = value.ToString(),
				 Selected = (selectedValue == value.ToString())
             };
            return items; 
    }
	
