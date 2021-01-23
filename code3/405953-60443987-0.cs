c#
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            string msg = "Close or not?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
