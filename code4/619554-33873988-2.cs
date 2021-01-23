    private const string ResetPasswordTokenPurpose = "RP";
    private const string ConfirmEmailTokenPurpose  = "EC";//change here change bit length for reason  section (2 per char)
    [TestMethod]
    public void GenerateTokenTest()
    {
        MyUser user         = CreateTestUser("name");
        user.Id             = 123;
        user.SecurityStamp  = Guid.NewGuid().ToString();
        var token   = sit.GenerateToken(ConfirmEmailTokenPurpose, user);
        var validation    = sit.ValidateToken(ConfirmEmailTokenPurpose, user, token);
        Assert.IsTrue(validation.Validated,"Token validated for user 123");
    }
