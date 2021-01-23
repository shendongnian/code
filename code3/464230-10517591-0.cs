      warningWindow.Dispatcher.Invoke(
          System.Windows.Threading.DispatcherPriority.Normal,
          new Action(
            delegate()
            {
              myCheckBox.IsChecked = true;
            }
        ));
