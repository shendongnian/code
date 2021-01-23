    private ObservableCollection<UserDTO> _users = new ObservableCollection<UserDTO>();
    private ServiceClient _client = new ServiceClient();
    public UserRepository()
    {
        Initialized = InitializeAsync();
    }
    public Task Initialized { get; private set; }
    private async Task InitializeAsync()
    {
        var tempList = await _client.GetUsersAsync();
        foreach(UserDTO item in tempList)
        {
            _users.Add(item);
        }
    }
