     private void ui_button_Click(object sender, RoutedEventArgs e)
      {
         if (MessageBox.Show("Do you want to change the background?", "Change background", MessageBoxButton.YesNo) == MessageBoxResult.No)
         {
            return;
         }
         Cursor = Cursors.Wait;
         BackgroundWorker bw = new BackgroundWorker();
         bw.DoWork += BwOnDoWork;
         bw.RunWorkerCompleted += BwOnRunWorkerCompleted;
         bw.RunWorkerAsync();
      }
      private void BwOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
      {
         if (Background != Brushes.Green)
         {
            Background = Brushes.Green;
         }
         else
         {
            Background = Brushes.White;
         }
         Cursor = Cursors.Arrow;
      }
      private void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
      {
         System.Threading.Thread.Sleep(1500);
      }
