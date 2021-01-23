    [Test]
    public void SomeTest()
    {
       this.moqSomeOtherClass.Setup(fd => fd.SomeMethod())
                             .Raises(fd => fd.SomeDelegate +=null);
    }
