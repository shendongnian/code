    [TestMethod]
    public void AddItem_Returns_A_Content_Result_With_The_Current_User_Id()
    {
        // arrange
        var sut = new HomeController();
        var cb = new TestControllerBuilder();
        cb.InitializeController(sut);
        var user = new MyUser(new GenericIdentity("john"), null)
        {
            Id = Guid.NewGuid(),
        };
        cb.HttpContext.User = user;
    
        // act
        var actual = sut.AddItem();
    
        // assert
        actual
            .AssertResultIs<ContentResult>()
            .Content
            .Equals(user.Id.ToString());
    }
