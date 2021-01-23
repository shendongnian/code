    private Event _eventItem;
    private DateTime? _viewDate;
    
    public event PropertyChangedEventHandler PropertyChanged;
    public RelayCommand CreateCommand { get; private set; }
    
    public Event EventItem
    {
        get { return _eventItem; }
        set { _eventItem = value; OnPropertyChanged("EventItem"); }
    }
    // Decoy DateTime property
    public DateTime? ViewDate
    {
        get { return _viewDate; }
        set
        { 
            _viewDate = value;
            EventItem.EventDate = _viewDate; // Update the source
            OnPropertyChanged("ViewDate");
        }
    }
    
    public MainViewModel()
    {
        EventItem = new Event();
        CreateCommand = new RelayCommand(CreateEvent);
    }
    private void CreateEvent()
    {
        ViewDate = DateTime.Today; // Important for resetting the calendar display
        // Save input and set EventItem to new event for a clean slate
    }
    
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
    
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
        // Important if you want your DatePicker control to be empty
        if(name.Equals("ViewDate") && DateTime.Today.Equals(ViewDate))
        {
            ViewDate = null;
        }
    }
