    public delegate void NotifyCallback(string message);
    
    public void loadData(NotifyCallback callback)
    {
      ClassWithCommandAndCallback ar = new ClassWithCommandAndCallback();
      ar.Sql = cmd;
      ar.Callback = callback;
      IAsyncResult result = cmd.BeginExecuteReader(new AsyncCallback(HandleCallback), ar, CommandBehavior.CloseConnection);
    }
    private void HandleCallback(IAsyncResult result)
    {
      ClassWithCommandAndCallback ar = (ClassWithCommandAndCallback)result.AsyncState;
      ar.Callback("loaded (SQL was: "+ar.Sql+")");
    }
