    CycleManager cycMan = CycleManager.Instance;            
    DateTime[] items = cycMan.GetHistoryArray();
    string[] list = new string[items.Length];
    for(int i=0; i<items.Length; i++)
    {
        list[i] = items[i].ToString("**The DateTime format you want**");
    }
    HistoryList = new ObservableCollection<string>(list);
    HistoryLV.ItemsSource = HistoryList;
