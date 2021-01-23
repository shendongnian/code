    protected override void OnStartupNextInstance(
      StartupNextInstanceEventArgs eventArgs)
    {
      base.OnStartupNextInstance(eventArgs);
      App.MyWindow.Activate();
      App.ProcessArgs(eventArgs.CommandLine.ToArray(), false);
    }
