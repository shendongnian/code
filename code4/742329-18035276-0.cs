        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (s, a) =>
            {
                this.Dispatcher.Invoke(new Action(() => MessageBox.Show("doing stuff")));
            };
            bw.RunWorkerCompleted += (s, a) =>
            {
                MessageBox.Show("done");
            };
            bw.RunWorkerAsync();
        }
