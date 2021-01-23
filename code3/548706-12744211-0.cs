    public void TransactFileCreation()
    {
        if (BatchFolderPath == null)
        {
             WPFMessageBox.Show("test", "Select a Batch folder");
             Application.Current.Shutdown();
        }
        // code..
    }
