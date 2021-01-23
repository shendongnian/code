	public partial class ChangeNameOnPKInCustomers : DbMigration
	{
		private static string fromName = "PK_dbo.Customers";	// Name to change
		private static string toName = fromName.Replace("dbo.", "");
		public override void Up()
		{
			Sql($"exec sp_rename @objname=N'[dbo].[{fromName}]', @newname=N'{toName}'");
			// Now the PK name is "PK_Customers".
		}
		
		public override void Down()
		{
			Sql($"exec sp_rename @objname=N'[dbo].[{toName}]', @newname=N'{fromName}'");
			// Back to "PK_dbo.Customers".
		}
	}
