    //populate with all your hosts and this will bind to your first datagrid
    private ObservableCollection<HostModel> _hostData= new ObservableCollection<Host>();
    public ObservableCollection<HostModel> HostData
    {
        get { return _hostData; }
        set { _hostData= value; OnPropertyChanged("HostData"); }
    }
    //populate with all the logs for the selected item and bind this to your second datagrid
    private ObservableCollection<LogFileModel> _logFileData = new ObservableCollection<LogFileModel>();
    public ObservableCollection<LogFileModel> LogFileData
    {
        get { return _logFileData; }
        set { _logFileData = value; OnPropertyChanged("LogFileData"); }
    }
    //when the user selects an item in the first datagrid this property will hold the value
    //so you will bind it to the selected item property of your first datagrid
    private Host _selectedHost; //initialise to avoid null issues
    public HostModelSelectedHost
    {
        get{ return _selectedItem; } 
        set 
        {
            //call a method to populate you second collection
            _selectedHost = value;
            logFileData = GetLogsForSelectedHost(_selectedHost);
            OnPropertyChanged("SelectedHost");
        { 
    }
    //the method for populating your second collection could look like this
    private ObservableCollection<LogFileModel> GetLogsForSelectedHost(_selectedHost)
    {
        ObservableCollection<LogFileModel> filteredLogs = new ObservableCollection<LogFileModel>;
        filteredLogs = //fill the collection with all the logs that match the host ID of
                       //your selected item
        return filteredLogs ;
    }
