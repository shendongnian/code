    public UserServiceTest() {
         _mockRepository = new MockRepository();
        _userRepository = MockRepository.GenerateMock<IUserRepository>();
        _userAccntService = new UserAccntService();
    }
