      protected override void OnStart(string[] args)
      {
          CreatFolder();
      }
      public static void CreatFolder()
      {
          //this.myTimer.Enabled = true;
          string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
          Directory.CreateDirectory(@"c:\ST\" + userName);
      }
