    private void LoadFromLocalStorage()
    {
        using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            string[] fileNames = store.GetFileNames();
    		var files = new ObservableCollection<string>();
    		
            foreach (string s in fileNames)
            {
    			files.Add(s);
            }
            lbFiles.ItemsSource = files;
        }
    }
