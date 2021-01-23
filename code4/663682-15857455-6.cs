    var query = db.CustomerContacts.Select(x => new {
        CustomerContactID = x.CustomerContactID,
        CustomerName = x.Owner.CustomerName,
        Phone = x.Phone,
    });
