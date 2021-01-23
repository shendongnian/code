    ViewBag.managers =  list_managers.Select(x => new SelectListItem
                              {
                                  Value = x.ID,
                                  Text = x.Name,
                                  Selected = ((int)id).Equals(x.ID)
                              })
                              .ToList();
