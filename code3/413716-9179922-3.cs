    void ChangeTab(ITabViewModel newTab)
    {
        // Set loading flag and set tab as Selected
        newTab.IsLoading = true;
        SelectedTab = newTab;
        // Create async task
        var asyncTask = new Task(() => newTab.LoadData());
        // This runs after task is finished running
        asyncTask.ContinueWith(p => newTab.IsLoading = false));
        // Start async task
        asyncTask.Start();
    }
