    [TestMethod]
    public void TestBuildChild()
    {
        var type = typeof(TestAnAbstractClass);
        var parameter = "A parameter";
        var child =(TestAnAbstractClass) this._factory.BuildChild(type, parameters);
        Assert.That(child.ConstructorParameter, Is.EqualTo(parameter));
    }
