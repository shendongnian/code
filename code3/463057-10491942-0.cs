    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
    
            Id(x => x.Id).Column("Id").CustomType("Int32").Access.Property()
             .CustomSqlType("int").Not.Nullable().Precision(10)
             .GeneratedBy.Identity();
    
            Map(x => x.Description).Column("Description").Nullable()
             .Generated.Never().CustomType(typeof (string)).Access
             .Property().Length(250);
    
            Map(x => x.Name).Not.Nullable().Generated.Never().CustomType("string")
             .Access.Property().Column("Name").Length(50);
    
            References(x => x.ParentCategory).Column("ParentCategoryId");
            HasMany(x => x.ChildCategories).KeyColumn("ParentCategoryId").Inverse()
             .Cascade.All();
        }
    }
