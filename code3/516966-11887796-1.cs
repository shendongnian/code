    items = new List<SelectListItem>();
    
    foreach (Person person in personList)
    {
        items.Add(new SelectListItem()
        {
            Value = person.Id,
            Text = person.FirstName + " " + person.LastName,
            Selected = person.Id == 4
        });
    }
    
    ViewData["personSelectList"] = items
