    public class MyDataService : ODataService<MyDataContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("Customers", EntitySetRights.All);
            config.SetEntitySetAccessRule("ResidentialCustomers", EntitySetRights.All);
            config.SetEntitySetAccessRule("Users", EntitySetRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.DataServiceBehavior.AcceptProjectionRequests = true; 
        }
    }
