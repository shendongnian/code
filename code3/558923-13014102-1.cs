    public override void Up() {
        CreateTable(
            "SomeTable",
             c => new {
                Id = c.Guid(nullable: false, defaultValueSql: "newsequentialid()"),
             })
             .PrimaryKey(t => t.Id)
        );
    }
