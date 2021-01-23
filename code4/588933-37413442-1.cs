    public static class DbContextExtensions
    {
        public static bool StoredProcedureExists(this DbContext context,
            string procedureName)
        {
            string query = String.Format(
                @"select top 1 from sys.procedures " +
                  "where [type_desc] = '{0}'", procedureName);
			return dbContext.Database.SqlQuery<string>(query).Any();
        }
    }
