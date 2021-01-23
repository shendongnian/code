    [Test]
    void Should_display_success_view_when_user_successfully_created()
    {
        var membershipProvider = new FakeMembershipProvider();
        membershipProvider.CreateStatus = MembershipCreateStatus.Success;
        var controller = new AccountController(membershipProvider);
        var model = new RegistrationModel();
    
        var result = controller.Register(model) as ViewResult;
    
        Assert.That(result.Name, Is.EqualTo("ExpectedViewName"));     
    }
