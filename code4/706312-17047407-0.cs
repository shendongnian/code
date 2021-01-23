    public override void Down()
    {
        Execute.Sql("update table foo set bar = 0 where bar is null");
        Alter.Table("foo").AlterColumn("bar").AsInt32().NotNullable();
    }
    
