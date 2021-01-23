    IEnumerable<SelectListItem> items = db.Attractions
        .AsEnumerable()
        .Select(c => new SelectListItem
        {
            Value = c.A_ID.ToString(),
            Text = c.Name
        });
