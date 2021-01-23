    class TheControl { 
      Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
      
      private void DoAction() {
        _dispatcher.Invoke(() => { 
          //Enable the Explore link to verify the package
          BuildExplorer.Visibility = Visibility.Visible;
        });
      }
    }
