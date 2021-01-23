        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label1Text = "It is coming...";
            
            var backgroundWorker = new BackgroundWorker();
            
            backgroundWorker.DoWork += (s,e) => {
              Thread.Sleep(3000);
            }
            backgroundWorker.RunWorkerCompleted += (s,e) => {
              Label2Text = "It is here!";
            }
            backgroundWorker.RunWorkerAsync();
        }
