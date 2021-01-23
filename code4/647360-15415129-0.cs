    public class WmTcpEventArgs : EventArgs {
      private string data;
      public WmTcpEventArgs(string text) {
        data = text;
      }
      public string Data { get { return data; } }
    }
