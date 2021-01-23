        using (NorthwindContext ctx = new NorthwindContext(NorthwindContext.ConnectionString))
        {
            ctx.DeleteDatabase();
            ctx.CreateDatabase();
            var category = new Categories();
            category.CategoryName = "Test";
            category.Description = new string('x', 6666);
            ctx.Categories.InsertOnSubmit(category);
            ctx.SubmitChanges();
            var testCat = ctx.Categories.First();
            if (testCat.Description.Length == 6666)
            {
                MessageBox.Show("Works on my Windows Phone");                
            }
        }
