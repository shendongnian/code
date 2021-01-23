    model.ProductCompanies = db.ProductCompanies
        .ToList()
        .Select(s => new SelectListItem
        {
            Text = s.Name,
            Value = s.Id.ToString()
        })
        .ToList();
