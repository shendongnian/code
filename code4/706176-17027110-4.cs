    model.managers =  list_managers.Select(x => new SelectListItem
                              {
                                  Value = x.ID.ToString(),
                                  Text = x.Name,
                                  Selected = ((int)id).Equals(x.ID)
                              })
                              .ToList();
