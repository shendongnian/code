    <script language="C#" runat="server">
    public void Application_OnStart()
    {
      Application["UsersOnline"] = 0;
    }
    
    public void Session_OnStart()
    {
      Application.Lock();
      Application["UsersOnline"] = (int)Application["UsersOnline"] + 1;
      Application.UnLock();
    }
    
    public void Session_OnEnd()
    {
      Application.Lock();
      Application["UsersOnline"] = (int)Application["UsersOnline"] - 1;
      Application.UnLock();
    }
    </script>
