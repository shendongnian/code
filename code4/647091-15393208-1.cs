    [Test]
    public void TestNewyear()
    {
        var newYear = new DateTime(2014, 1, 1);
        var complexClass = new ComplexClass(new Lazy<DateTime>(() => newYear));
    
        Assert.AreEqual("New year!", complexClass.GetDay());
    }
