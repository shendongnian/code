     public class MyEfConfigurations : DbConfiguration
        {
            public MyEfConfigurations()
            {
                SetExecutionStrategy("System.Data.SqlClient",() => new MyCustomExecutionStrategy(5,TimeSpan.FromSeconds(10)));
            }
        }
