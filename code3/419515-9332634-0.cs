       private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (button.Content == "Start")
            {
                button.Content = "Stop";
                cts.Dispose(); // Clean up old token source....
                cts = new CancellationTokenSource(); // "Reset" the cancellation token source...
                DoWork(cts.Token);
            }
            else
            {
                button.Content = "Start";
                cts.Cancel();
            }
        }
