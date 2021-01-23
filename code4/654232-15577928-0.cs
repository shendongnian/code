    database.Stores.Where(s => s.CompanyID == curCompany.ID)
                   .Select(s => new SelectListItem
                       {
                           Value = s.Name,
                           Text = s.ID
                       });
