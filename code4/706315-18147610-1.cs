    public override void Down()
    {
        Update.Table("foo").Set(new { bar = 0 }).Where(new { bar = (int?) null });
        Alter.Table("foo").AlterColumn("bar").AsInt32().NotNullable();
    }
