    progressWindow.Show();
    this.DoEvents();
    public static void DoEvents(this Window _)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                                  new Action(delegate { }));
        }
