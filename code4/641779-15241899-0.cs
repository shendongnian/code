    var results = col
        .GroupBy(posting => new
            {
                Category = posting.Category.Description,
                SubCategory = posting.SubCategory.Description
            })
        .GroupBy(group => group.Key.Category.Description);
