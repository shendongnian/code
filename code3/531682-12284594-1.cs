            [TestMethod]
            public void Register_HttpPost_ValidViewModel_ReturnsRegisterSuccess()
            {
                // Arrange
                var autoMapperMock = this.mockRepository.DynamicMock<IMapper>();
                var userManagementServiceMock = this.mockRepository.DynamicMock<IUserManagementService>();
    
                var invalidRegistrationViewModel = new NewUserViewModel
                {
                    LastName = "Lastname",
                    FirstName = "Firstname",
                    Username = null
                };
    
                autoMapperMock.Expect(a => a.Map<UserDTO, UserViewModel>(Arg<UserDTO>.Is.Anything)).Repeat.Once().Return(null);
                autoMapperMock.Expect(a => a.Map<NewUserViewModel, NewUserDTO>(Arg<NewUserViewModel>.Is.Anything)).Repeat.Once().Return(null);
                userManagementServiceMock.Expect(s => s.RegisterUser(Arg<NewUserDTO>.Is.Anything)).Repeat.Once();
                
                autoMapperMock.Replay();
                
                var controller = new AccountController
                {
                    Mapper = autoMapperMock,
                    UserManagementService = userManagementServiceMock
                };
    
                this.mockRepository.ReplayAll();
    
                // Act
                var result = (RedirectToRouteResult)controller.Register(invalidRegistrationViewModel);
    
                // Assert
                Assert.IsTrue((string)result.RouteValues["Action"] == "RegisterSuccess");
            }
