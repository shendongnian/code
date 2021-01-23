    var query = db.CustomerContacts
        .Include(x => x.Owner) // eager load to avoid multiple separate SQL queries
        .Select(x => new {
            CustomerContactID = x.CustomerContactID,
            CustomerName = x.Owner.CustomerName,
            Phone = x.Phone,
    });
