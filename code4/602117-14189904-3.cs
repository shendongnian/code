    public UsersViewModel()
    {
        _repo = new UserRepository();
        Initialized = InitializeAsync();
    }
    public Task Initialized { get; private set; }
    private async Task InitializeAsync()
    {
        // Wait for the repository to initialize
        await _repo.Initialized;
        foreach (UserDTO item in _repo.Users)
        {
            _users.Add(new UserViewModel(item.Id));
        }
    }
