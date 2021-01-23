    public override void Up()
    {
        Sql("ALTER TABLE dbo.Received DROP CONSTRAINT DF_Receiv_FromN__25869641");
        AlterColumn("dbo.Received", "FromNo", c => c.String());
        AlterColumn("dbo.Received", "ToNo", c => c.String());
        AlterColumn("dbo.Received", "TicketNo", c => c.String());
    }
