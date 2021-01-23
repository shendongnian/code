    var model = Session.Query<Contact>()
                       .Where(c => c.UserId == this.userId)
                       .AsEnumerable()
                       .Select(c => new SelectListItem { 
                                      Text = c.FullName, 
                                      Value = c.Id })
                       .ToList();
