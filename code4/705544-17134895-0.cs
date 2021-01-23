    private ActionResult Save(Business business)
    {
        if (business.BusinessId > 0) // = business exists
        {
            var businessInDb = Context.Businesses
                .Include(b => b.Categories)
                .Single(b => b.BusinessId == business.BusinessId);
            // Update parent properties (only the scalar properties)
            Context.Entry(businessInDb).CurrentValues.SetValues(business);
            // Delete relationship to category if the relationship exists in the DB
            // but has been removed in the UI
            foreach (var categoryInDb in businessInDb.Categories.ToList())
            {
                if (!business.Categories.Any(c =>
                    c.CategoryId == categoryInDb.CategoryId))
                    businessInDb.Categories.Remove(categoryInDb);
            }
            // Add relationship to category if the relationship doesn't exist
            // in the DB but has been added in the UI
            foreach (var category in business.Categories)
            {
                var categoryInDb = businessInDb.Categories.SingleOrDefault(c =>
                    c.CategoryId == category.CategoryId)
                if (categoryInDb == null)
                {
                    Context.Categories.Attach(category);
                    businessInDb.Categories.Add(category);
                }
                // no else case here because I assume that categories couldn't have
                // have been modified in the UI, otherwise the else case would be:
                // else
                //   Context.Entry(categoryInDb).CurrentValues.SetValues(category);
            }
        }
        else
        {
            // see below
        }
        Context.SaveChanges();
        
        return RedirectToAction("Index");
    }
