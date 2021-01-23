    public ObservableCollection<string> SystemUsers { get; private set; }
    public UserControl()
    {
        this.InitializeComponent();
        this.SystemUsers = new ObservableCollection<string>();
    }
    private void OnUserSearchComplete(IAsyncResult result)
    {
        var query = result.AsyncState as DataServiceQuery<SystemUser>;
        IEnumerable<SystemUser> response = query.EndExecute(result);
        this.SystemUsers.Clear();
        foreach (SystemUser record in response)
        {
            this.SystemUsers.Add(record.FullName);
        }
    }
