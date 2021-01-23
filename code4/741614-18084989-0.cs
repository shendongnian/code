    public class Vista : DataService<VistaContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule(...);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            ...
        }
    }
