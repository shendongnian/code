    protected override void Seed(EFDbContext context)
    {
        // This will be executed in every Build configuration
        context.Table1.AddOrUpdate(new Table1 { Field1 = "Foo", Field2 = "Bar" });
    
        #if DEBUG
            // This will only be executed if DEBUG is defined, hence when you are debugging
            context.Table1.AddOrUpdate(new Table1 { Field1 = "Blah", Field2 = "De Blah" });
            context.Table2.AddOrUpdate(new Table2 { Field1 = "Development Only" });
        #endif
    }
