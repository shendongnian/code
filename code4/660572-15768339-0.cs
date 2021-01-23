    var mock = new Mock<IUnitOfWork>();
            mock.Setup(u => u.UserRepository.Get("test1", null, "")).Returns(
                new List<User>
            {
                new User { UserId = 4, FirstName = "Test4", LastName = "LastName", Email = "test4@test.com", Salt = salt, Password = pass, AccountConfirmed = true, PassResetCode = "test1", PassResetExpire = new Nullable<DateTime>(DateTime.Now.Add(ts)) },                
            });
