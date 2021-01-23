    void Control_Unloaded(object sender, RoutedEventArgs e)
    {
      // flush dispatcher
      this.Dispatcher.BeginInvoke(new Action(DoMemoryAnalysis), DispatcherPriority.ContextIdle);
    }
    private static void DoMemoryAnalysis()
    {
      GC.Collect();
      GC.WaitForPendingFinalizers();
      // do memory analysis now.
    }
