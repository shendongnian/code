        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Currently running on the WPF thread so the WPF property can be set directly
            this.progressBar1.Visibility = System.Windows.Visibility.Visible;
            // Create a new thread to do the long running task
            Thread worker = new Thread(() =>
            {
                WebService.DoSomethingThatTakesAges();
                // When the above call has completed, update the UI on its dispatcher thread
                this.progressBar1.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.progressBar1.Visibility = System.Windows.Visibility.Hidden;
                    }));
            });
            worker.Start();
        }
