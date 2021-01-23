    var ids = so.Select(i=>i.PersonId).Distinct().ToList();
    // Hitting Database just for this time to get all Users Ids
    var usersIds = db.Entity.Where(u=>ids.Contains(u.ID)).Select(u=>u.ID).ToList();
    foreach (var item in so)
                    {
                        if (usersIds.Contains(item.PersonId))
                        {
                            item.ValidationResult = "Successful";
                        }
                        else
                        {
                            item.ValidationResult = "Error:  ";
                        }
                     } 
    
    return View(so.ToList());
