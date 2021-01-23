    internal class CommonDataTool
    {
        internal delegate object SqlCommandDelegate();
    
        /// <summary>
        /// Use only for select where (a) return value(s) is/are expected and/or required
        /// </summary>
        /// <typeparam name="T"> Expected datacontext model return type, example: DataContext.User</typeparam>
        /// <param name="context"> The DataContext (YourDataModel) instance to be used in the transaction </param>
        /// <param name="action"> Linq to Entities action to perform</param>
        /// <returns> Returns an object that can be implicitly casted to List of T where T is the expected return type. Example: List of DataContext.User</returns>
        internal List <T> ExecuteSelect<T>(YourDataModel context, SqlCommandDelegate action)
        {
            using (context)
            {
                var retVal = action(); return ((ObjectQuery<T>)retVal).ToList();
            }
        }
    
        /// <summary>
        /// Use for updates and inserts where no return value is expected or required
        /// </summary>
        /// <param name="context"> The DataContext (YourDataModel) instance to be used in the transaction </param>
        /// <param name="action"> Linq to Entities action to perform</param>
        internal void ExecuteInsertOrUpdate(YourDataModel context, SqlCommandDelegate action)
        {
            using (context)
            {
                using (var transaction = context.BeginTransaction())
                {
                    try
                    { action(); context.SaveChanges(); transaction.Commit(); }
                    catch (Exception )
                    { transaction.Rollback(); throw; }
                }
            }
        }
    }
    
    public static class ObjectContextExtensionMethods
    {
        public static DbTransaction BeginTransaction( this ObjectContext context)
        {
            if (context.Connection.State != ConnectionState .Open) { context.Connection.Open(); }
            return context.Connection.BeginTransaction();
        }
    }
