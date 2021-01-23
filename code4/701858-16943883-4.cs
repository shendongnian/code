    public class MyService
    {
      ...
      public MyService() {
        HubToServiceProxy.Instance.RegisterService(this);
      }
      ...
    }
    public class MyHub : Hub
    {
      public void SendToServer(string data)
      {
        HubToServiceProxy.Instance.SendCommandToService(data);
      }
    }
