    var items = context.Items.GroupBy(i => new { i.Name, i.Model })
        .Where(/*...*/) 
        .Select(g =>
            g.OrderBy(i => i.Name).Select(i => new ItemModel
            {
                Name = i.Name,
                SerialNumber = i.SerialNumber,
            }).FirstOrDefault()
        );
