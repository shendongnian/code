    var list_managers =  list_managers.Select(x => new
                              {
                                  Value = x.ID.ToString(),
                                  Text = x.Name
                              })
                              .ToList();
    ViewBag.managers = new SelectList(list_managers, "ID", "NAME", id);
