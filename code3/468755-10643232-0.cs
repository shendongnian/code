    private ObservableCollection<string> _twitterFriendList;
    private ObservableCollection<string> _facebookFriendList;
    private ObservableCollection<string> _selectedFriendList;
    public ObservableCollection<string> SelectedFriendList
    {
        get { return _selectedFriendList; }
        set
        {
            if (value != _selectedFriendList)
            {
                _selectedFriendList = value;
                RaisePropertyChanged("SelectedFriendList");
            }
        }
    }    
    void TwitterButton_Click(object sender, RoutedEventArgs e) 
    {
        SelectedFriendList = _twitterFriendList;
    } 
    void FacebookButton_Click(object sender, RoutedEventArgs e) 
    {
        SelectedFriendList = _facebookFriendList;
    } 
