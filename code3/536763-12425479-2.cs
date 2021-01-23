    CreateTable(
        "dbo.CustomerDirectory",
         c => new
            {
                Uid = c.Int(nullable: false),
                CustomerUid = c.Int(nullable: false),
                Description = c.String(nullable: false, maxLength: 50, unicode: false),
                RowGuid = c.Guid(nullable: false),
            })
        .PrimaryKey(t => t.Uid)
        .ForeignKey("dbo.Customer", t => t.CustomerUid)
          //SqlValue is a custom static helper class
        .DefaultConstraint( t => t.Description, SqlValue.EmptyString)
          //This is a convention in the project
          //Equivalent to
          //  .DefaultConstraint( t => t.RowGuid, SqlValue.EmptyString)
          //  .RowGuid( t => t.RowGuid )
        .StandardRowGuid()
          //For one-offs
        .Sql( tableName => string.Format( "ALTER TABLE {0} ...", tableName" );
