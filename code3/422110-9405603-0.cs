    static T Invoke<T>(Func<T> method)
    {
      //Log here
      return method();
    }
    bool RemoteLogin(string password)
    {
      return Invoke(() => Server.RemoteLogin(password));
    }
