    public class GeneralEntitiesConfiguration
    {
        public GeneralEntitiesConfiguration(ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(new YourEntityConfiguration());
            //and additional configurations for each entity, just to splitt it a bit and have it more read and maintenance able
        }
    }
