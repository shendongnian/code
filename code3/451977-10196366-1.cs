    var DateVM = new DateSearchViewModel 
    {
        ...
        Days = new List<SelectListItem>(),
        ...
    }
    for (var i = 1; i <= 31; i++)
    {
        DateVM.Days.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString()});
    }
