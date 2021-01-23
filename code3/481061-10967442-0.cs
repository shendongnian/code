    progress.Dispatcher.Invoke(
          System.Windows.Threading.DispatcherPriority.Normal,
          new Action(
            delegate()
            {
                    LblProgress.Content = "Downloading Drivers";
                    progress.Value = 30;
            }
        ));
