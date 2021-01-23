	using Brass9.Data.Entity.Migrations;
	
	public partial class FillZips : ExpandedDbMigration
	{
		public override void Up()
		{
			SqlFile(@"Migrations\Sql\2013-08-15 FillTable.sql");
		}
