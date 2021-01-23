    public ObservableCollection<Host> hosts = //populate with all your hosts
    public ObservableCollection<Log> logsOfSelectedHost;
    //when the user selects an item in the first datagrid this property will hold the value
    public Host SelectedItem
    {
        get; 
        set { //when this value is set you can populate `logsOfSelectedHost` with the logs
        //matching the foreign key value
    }
