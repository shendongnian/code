    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    [ServiceContract(SessionMode = SessionMode.Required)]
    public class MyService : IMyService {
        // this is your static data store which is accessible from all your sessions
        private static List<string> strList = new List<string>();
        // an object to synchronize access to strList
        private static object syncLock = new object();
        public void AddAction(string data) {
            // be sure to synchronize access to the static member:
            lock(syncLock) {
                strList.Add(data);
            }
        }
   
    }
