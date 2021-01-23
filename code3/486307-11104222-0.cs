    public interface IReadSecureSite
    {
      IEnumerable<String> AccessHistory { get; }
    }
    class Write_SecureSite : IReadSecureSite
    {
        public IList<String> AccessHistoryList { get; private set; }
        public Write_SecureSite()
        {
            AccessHistoryList = new List<string>();
        }
        
        public IEnumerable<String> AccessHistory {
            get {
                return AccessHistoryList;
            }
        }
     }
     public class Controller
     {
        private Write_SecureSite sec= new Write_SecureSite();
        public IReadSecureSite Login(string user)
        {
           return sec;
         }
 
     }
     ...
     Controller ctrl = new Controller();
     IReadSecureSite read = ctrl.Login("me");
     foreach(string user in read.AccessHistory)
     {
     }
       
