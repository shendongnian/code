    var ceremonies = db.Ceremonies
                       .Select(c => new { c.Name, c.Date, c.Id }
                       .AsEnumerable()
                       .Select(c => new SelectListItem {
                                   Text = c.Name + "_" + c.Date, 
                                   Value = c.Id.ToString()
                               });
