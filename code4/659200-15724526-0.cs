    void runBootStrapProcess() {
      MetadataReader mr = new MetadataReader();
      if (currentVersionNo.Equals(remoteVersionNo)) {
        Application.Current.Shutdown();
      } else {
        System.Windows.Application.Current.Dispatcher.BeginInvoke(
        new Action(
          () => {
            MainWindow mw = new MainWindow();
            mw.Show();
          }));
      }
      _loadingProgressBar.ShouldCloseNow = true;
    }
