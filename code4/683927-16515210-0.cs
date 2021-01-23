     Id(x => x.Id).GeneratedBy.Native();
 
        Map(x => x.Name)
            .Length(200)
            .Not.Nullable();
 
        References(x => x.ParentCategory)
            .Column("ParentCategoryId")
            .Access.CamelCaseField();
 
        HasMany(x => x.ChildCategories)
            .Cascade.AllDeleteOrphan()
            .AsSet()
            .KeyColumn("ParentCategoryId")
            .Access.CamelCaseField();
