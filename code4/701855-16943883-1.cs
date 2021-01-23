    public class HubToServiceProxy {
      public static readonly HubToServiceProxy Instance = new HubToServiceProxy();
      private HubToServiceProxy() {}
      private MyService m_svc;
      // call this when the service starts up, from the service
      public void RegisterService (MyService svc) {
        m_svc = svc;
      }
      // call this from the hub instance to send a message to the service
      public void SendCommandToService(string data) {
        svc.LocalCommand(data, null);
      }  
    }
