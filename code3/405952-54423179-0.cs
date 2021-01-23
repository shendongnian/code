    private void buttonCloseTheApp_Click (object sender, RoutedEventArgs e) {
      IsNonCloseButtonClicked = true;
      this.Close (); // this will trigger the Closing () event method
    }
    private void MainWindow_Closing (object sender, System.ComponentModel.CancelEventArgs e) {
      if (IsNonCloseButtonClicked) {
        e.Cancel = !IsValidated ();
        // Non X button clicked - statements
        if (e.Cancel) {
          IsNonCloseButtonClicked = false; // reset the flag
          return;
        }
      } else {
        // X button clicked - statements
      }
    }
