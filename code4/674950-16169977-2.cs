    public void Populate()
    {
        BrowserInstance selectedItem = m_SelectedItem;
        List<BrowserInstance> items = new List<BrowserInstance>();
        foreach (Process process in Process.GetProcessesByName("chrome"))
            items.Add(new BrowserInstance(process));
        m_Enabled = items.Any();
        m_Items = new ObservableCollection<BrowserInstance>(items.OrderBy(x => x.Process.Id));
        if(!m_Enabled)
            m_Items.Add(new BrowserInstance());
        NotifyPropertyChanged("Enabled");
        NotifyPropertyChanged("Items");
        if (SelectedItem == null)
            SelectedItem = m_Items[0];
    }
