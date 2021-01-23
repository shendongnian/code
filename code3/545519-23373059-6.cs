    /// <summary>
    ///     Seeds the specified context.
    /// </summary>
    /// <param name="context">The context.</param>
    protected override void Seed(Test.Infrastructure.TestDataContext context)
    {
        // Generate the root element.
        var root = new Category { Name = "First Category" };
        // Add a set of children to the root element.
        root.AddChildren(new HashSet<Category>
        {
            new Category { Name = "Second Category"},
            new Category { Name = "Third Category" }
        });
        // Add a single child to the root element.
        root.AddChild(new Category {Name = "Fourth Category"});
        // Add the root element to the context. Child elements will be saved as well.
        context.Categories.AddOrUpdate(cat => cat.Name, root);
        // Run the generic seeding method.
        base.Seed(context);
    }
