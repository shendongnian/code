    public class RejectService
    {
        Dictionary<RejectInformation, Action<RejectInformation>> pendingNotifications = new Dictionary<RejectInformation, Action<RejectInformation>>();
    
        public void SubmitNewRejectInfo(RejectInformation rejectInformation)
        {
           OnSubmitNewRejectInfo(new RejectInfoArgs(rejectInformation));
           pendingNotifications.Add(rejectInformation, info => callback.RejectCallback(info));
        }
    
        public void SendRejectCallback(RejectInformation rejectInformation)
        {
           Action<RejectInformation> action;
           if (pendingNotifications.TryGetValue(rejectInformation, out action))
           {
              acion(rejectInformation);
              pendingNotifications.Remove(rejectInformation);
           }
        }
    }
