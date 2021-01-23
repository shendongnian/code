    [Export("Print", typeof(IPlugin))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    class Print : IPlugin
    {
      .
      .
      .
      public Fire()
      {
        //Do something;
      }
    }
    class PrintMenuItem
    {
      IPlugin _plugin;
      [ImportingConstructor]
      PrintMenuItem([Import("Print", typeof(IPlugin)] plugin)
      {
        _plugin = plugin;
      }
      void Execute()
      {
        _plugin.Fire();
      }
    }
