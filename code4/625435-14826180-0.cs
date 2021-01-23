    public partial class AddingUsernameIndexes : DbMigration
    {
    	public override void Up()
    	{
    		Sql("CREATE NONCLUSTERED INDEX IX_Applications_Username ON RequestApplications (Username)");
    	}
    	
    	public override void Down()
    	{
    		Sql("DROP INDEX IX_Applications_Username");
    	}
    }
