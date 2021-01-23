    public class SQLCLRProcedure : IDisposable
    {
         public bool Execute(Guid guid)
         {
               // Do work
         }
         public void Dispose()
         {
               // Remove GUID
               // Close Connection
         }
    }
    using (SQLCLRProcedure procedure = new SQLCLRProcedure())
    {
      procedure.Execute(guid);
    }
