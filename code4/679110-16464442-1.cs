     public class SimpleService : ServiceBase {
        ...
        public SimpleService()
        {
            CanPauseAndContinue = true;
            CanHandleSessionChangeEvent = true;
            ServiceName = "SimpleService";
        }
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() +
                " - Session change notice received: " +
                changeDescription.Reason.ToString() + "  Session ID: " + 
                changeDescription.SessionId.ToString());
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    EventLog.WriteEntry("SimpleService.OnSessionChange: Logon");
                    break;
                case SessionChangeReason.SessionLogoff:       
                    EventLog.WriteEntry("SimpleService.OnSessionChange Logoff"); 
                    break;
               ...
            }
