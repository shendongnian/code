    var items = _repository.GetItems()
        .Select(og => {
		    dynamic eo = new System.Dynamic.ExpandoObject();
    		eo.Id = item.Id;
	    	eo.FriendlyName = og.FriendlyName;
		    eo.Selected = itemIds.Contains(item.Id);
    		return eo;
	    })
        .ToArray();
    ViewBag.Items = items;
