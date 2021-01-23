    void ChangeTab(ITabViewModel newTab)
    {
        newTab.IsLoading = true;
        SelectedTab = newTab;
        Task.Factory.StartNew(() => newTab.LoadData());
        newTab.IsLoading = false;
    }
