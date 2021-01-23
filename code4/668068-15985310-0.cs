    var itemPerCategories = 
            db.Category.ToDictionary(
                c => c.CategoryName,
                c => c.Tags.SelectMany(t => t.Items)).ToList())
            );
