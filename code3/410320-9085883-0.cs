    [Test]
    public void CallingSumResets()
    {
        var calc = new Calculator();
        calc.Add(10);
        Assert.AreEqual(10, calc.Sum());
        Assert.AreEqual(0, calc.Sum());
    }
