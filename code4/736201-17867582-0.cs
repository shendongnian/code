    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)] 
    public class Service : IService
    {
        private string sessionVariable;         // separate for each session
        private static string globalVariable;   // shared across all sessions
    }
