    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBox.Show(e.Error.Message);
        }
        else
        {
            SystemTray.IsVisible = false;
 	    TasksListBox.ItemsSource = (this.DataContext as MainViewModel).Tasks;
        }
    }
    private void LoadData()
    {
        (this.DataContext as MainViewModel).LoadInboxData();
    }
