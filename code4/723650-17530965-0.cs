    using(var dbContext = new DbContext())
    {
        var categoryToChange = new Categories()
        {
            // set properties to original data
        };
        dbContext.Categories.Attach(categoryToChange);
        // set changed properties
        dbContext.SaveChanges();
    }
