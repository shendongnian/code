    [Test]
    public void EmailTest()
    {
        var pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        var address = "abcde@gmail.com";
        Assert.IsTrue(Regex.IsMatch(address, pattern,RegexOptions.IgnoreCase));
        Assert.IsTrue(regex.IsMatch(address));
    }
