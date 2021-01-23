    var query = service.Mail.Where("ProjectId = 37 AND CreatedByUserId == 55");
    
    if (!String.IsNullOrWhiteSpace(item.DateModified))
    {
        query = query.DynamicWhere(k => k["DateModified"] > DateTime.Today.AddHours(-2));
    }
