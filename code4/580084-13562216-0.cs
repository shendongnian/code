    public interface IConnection<T>
    {
      void Connect(string user, string pw, Action<T[]> onConnect);
      void Disconnect();
    }
