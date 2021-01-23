        IEnumerable<SelectListItem> items = db.Attractions
          .ToList()
          .Select(c => new SelectListItem
          {
              Value = c.A_ID.ToString(),
              Text = c.Name
          });
