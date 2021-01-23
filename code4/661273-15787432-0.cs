    [Test]
    public void IsValidEmailTest()
    {
        Assert.IsTrue( IsValidEmail( "name+@domain.com" ) );
        Assert.IsTrue( IsValidEmail( "name@domain.com" ) );
        Assert.IsFalse( IsValidEmail( "namedomain.com" ) );
        Assert.IsFalse( IsValidEmail( "namedomaincom" ) );
        Assert.IsFalse( IsValidEmail( "named@omaincom" ) );
    }
