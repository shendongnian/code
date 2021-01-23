    public static class DbContextExtensions
    {
        public static bool StoredProcedureExists(this DbContext context,
            string procedureName)
        {
            string query = String.Format(@"select [name] from sysobjects where " +
               "type='P' and name='{0}'", procedureName);
			return dbContext.Database.SqlQuery<string>(query).Any();
        }
    }
