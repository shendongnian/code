    var choices = new List<Item>();
    choices.Add(new SelectListItem()
    {
        Text = "Unselected",
        Value = null;
        Selected = ClientSinceYearsOnly == null
    };
    choices.AddRange(
        Enumerable.Range(1950, DateTime.Now.Year - 1951)
        .Select(x => new SelectListItem() 
        { 
            Text = x.ToString(), 
            Value = new DateTime(x, 1, 1).ToString(),
            Selected = x == ClientSinceYearOnly
        });
