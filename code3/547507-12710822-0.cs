    var categories = _db.Categories.Select(x => new {
            ID = x.ID,
            Name = x.NameLatvian,
            ItemCount = x.Items.Count
        })//restrict the columns returned from the db
        .AsEnumerable()//Switch to Linq-to-objects
        .Select(x => new {
            x.ID,
            Breadcrumbs = Infrastructure.CategoryHelpers.Breadcrumbs(x.ID, -1, ""),
            x.Name,
            x.ItemCount,
        });
