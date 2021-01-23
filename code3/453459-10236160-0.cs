    return new[] { new SelectListItem { Text = ... } }.Concat(
           from s in db.List
           orderby s.Descript
           select new SelectListItem
           {
               Text = s.Descript,
               Value = s.ID.ToString(),
               Selected = (s.ID == ID)
           });
