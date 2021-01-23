    /// <summary>
      /// Extension method that allows for automatic anonymous method invocation.
      /// </summary>
      public static void Invoke(this Control c, MethodInvoker mi)
      {
         c.Invoke(mi);
    
         return;
      }
    
    
    private void onServerInfo(msgBox message)
    {
    this.Invoke
    (
       () =>
       {
        serverInfo.info info = (serverInfo.info)message.getMessage("info");
        MessageBox.Show(info.name + " ; " + info.type + " ; " + info.limit); // works with everything showing up right
        ServerName.Text = info.name; //this is a string
        ServerType.Text = info.type.ToString(); // this is a enum
        MaxLimit.Text = info.limit.ToString(); // this is a int
        MessageBox.Show(ServerName.Text + " ; " + ServerType.Text + " ; " + MaxLimit.Text); // doesnt ever show
       }
    );
    }
