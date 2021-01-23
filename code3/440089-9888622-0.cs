    private class Thrower
    {
        public void ThrowAE() { throw new ArgumentException(); }
    }
    [Test]
    public void ThrowETest()
    {
        var t = new Thrower();
        Assert.That(() => t.ThrowAE(), Throws.Exception);
    }
