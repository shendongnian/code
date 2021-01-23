    var mockedDependency = MockRepository.GenerateMock<IDependency>();
    mockedDependency.Expect(x => x.SomeMethod())
                    .Returns("whatever your test dictates");
    var target = new SomeClass(mockedDependency);
    mockedDependency.VerifyAllExpectations();
