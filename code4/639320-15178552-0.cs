    private void UpdateWithOriginal(Category cat, string name)
            {
                Category updatedObject = new Category()
                {
                    CategoryID = cat.CategoryID,
                    Name = cat.Name,
                    Topics = cat.Topics
                };
                updatedObject.Name = name;
                using (TestContext ctx = new TestContext())
                {
                    ctx.Categories.Attach(updatedObject);
                    ctx.ApplyOriginalValues("Categories", cat);
                    var state = ctx.ObjectStateManager.GetObjectStateEntry(updatedObject).State;  //never modified state here
                    ctx.SaveChanges();
                }
            }
