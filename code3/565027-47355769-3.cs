    public class EFPolicy: DbConfiguration
    {
        public EFPolicy()
        {
            SetExecutionStrategy(
                "System.Data.SqlClient",
                () => new EFRetryPolicy());
        }
    }
