    //before using the context the first time i'm calling, you can ignore the connection string
    DbContextInitializer.Init(conString);
    public static class DbContextInitializer
    {
        public static void Init (string connectionString)
        {
            Database.SetInitializer(new CreateDbThrowExceptionIfModelDiffersInitializer<SMDbContext>());
            using(var dbContenxt = new MyDbContext(connectionString))
            {
                try
                {
                    dbContenxt.Database.Initialize(true);
                }
                catch(DatabaseModelDiffersException diffException)
                {
                    // some magic...
                }
                catch(Exception ex)
                {
                    // TODO: log
                    throw;
                }
            }
        }
        public class CreateDbThrowExceptionIfModelDiffersInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
        {
            public void InitializeDatabase(TContext context)
            {
                using (new TransactionScope(TransactionScopeOption.Suppress))
                {
                    if (!context.Database.Exists())
                        context.Database.Create();
                }
                if (!context.Database.CompatibleWithModel(true))
                {
                    throw new DatabaseModelDiffersException("Database Model differs!");
                }
            }
            protected virtual void Seed(TContext context)
            {
                // create data if you like
            }
        }
        // just an exception i'm using for later useage
        public class DatabaseModelDiffersException : Exception
        {
            public DatabaseModelDiffersException(string msg) : base(msg)
            {}
        }
    }
