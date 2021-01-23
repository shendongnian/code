    protected override void OnAfterInstall(IDictionary savedState)
    {
          base.OnAfterInstall(savedState);
          System.ServiceProcess.ServiceController sc = new System.ServiceProcess.ServiceController(serviceInstaller1.ServiceName);
          sc.Start();
    }
