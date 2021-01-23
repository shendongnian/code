    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single, AutomaticSessionShutdown = true)]
    public class SampleService : ISampleService
    {
        SampleEntities datacontext = null;
        public void Login(string user, string password, int entityID)
        {
           if(CheckLoginData(user, password))
           {
             InitDataContext(entity_id);
           }
        }
        private void InitDataContext(int entityID)
        {
           var connectionString = GetConnectionStringFromEntityID(entityID);
           datacontext = new SampleEntities(connectionString);
        }
    }
