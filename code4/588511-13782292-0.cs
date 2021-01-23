    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
           MessageBox.Show("Error", "!", MessageBoxButton.OK, MessageBoxImage.Error);
           return;
        }
    }
