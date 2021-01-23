    static internal class MigrationExtensions
    {
    	public static void DeleteDefaultContraint(this IDbMigration migration, string tableName, string colName, bool suppressTransaction = false)
    	{
    		var sql = new SqlOperation(String.Format(@"DECLARE @SQL varchar(1000)
    		SET @SQL='ALTER TABLE {0} DROP CONSTRAINT ['+(SELECT name
    		FROM sys.default_constraints
    		WHERE parent_object_id = object_id('{0}')
    		AND col_name(parent_object_id, parent_column_id) = '{1}')+']';
    		PRINT @SQL;
    		EXEC(@SQL);", tableName, colName)) { SuppressTransaction = suppressTransaction };
    		migration.AddOperation(sql);
    	}
    }
    	
    public override void Up()
    {
    	this.DeleteDefaultContraint("dbo.Received", "FromNo");
    	AlterColumn("dbo.Received", "FromNo", c => c.String());
    	this.DeleteDefaultContraint("dbo.Received", "ToNo");
    	AlterColumn("dbo.Received", "ToNo", c => c.String());
    	this.DeleteDefaultContraint("dbo.Received", "TicketNo");
    	AlterColumn("dbo.Received", "TicketNo", c => c.String());
    }
