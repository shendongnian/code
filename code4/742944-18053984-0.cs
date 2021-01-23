    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
       startButton.IsEnabled = false;
    }
     void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
     {
        stratButton.IsEnabled = true;
     }
