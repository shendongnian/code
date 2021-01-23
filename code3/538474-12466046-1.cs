    IEnumerable<SelectListItem> items = db.Locations
          .Select(c => new
          {
              c.id,
              c.location_name
          });
          .AsEnumerable()
          .Select(c => new SelectListItem
          {
              Value = c.id.ToString(),
              Text = c.location_name
          });
