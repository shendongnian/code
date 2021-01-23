    private MembershipUser GetMembershipUser(string s)
    {
        Mock<MembershipUser> user =new Mock<MembershipUser>();
        user.Setup(item => item.ProviderUserKey).Returns(GetProperty(s));
        return user.Object;
    }
