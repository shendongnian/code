    model.CategoryMenu = db.Categories.Select(c => new SelectListItem {
                                                        Text = c.Name,
                                                        Value = c.Id.ToString(),
                                                       }
                                              );
