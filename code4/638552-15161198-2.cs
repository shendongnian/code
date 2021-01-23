    private IUser CreateUser(string userName)
    {
        var userMock = MockRepository.GenerateMock<IUser>();
        userMock.Expect(x => x.UserName).Return(userName);
        return userMock;
    }
