    public bool TransactFileCreation()
    {
        if (BatchFolderPath == null)
        {
             WPFMessageBox.Show("test", "Select a Batch folder");
             return false;
        }
        // code..
        return true;
    }
