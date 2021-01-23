    [Test]
    public void StartsWithFiltersFooFromRepository()
    {
        var fooFromRepository = new List<Foo> { new Foo {Name="yes1"}, new Foo {Name="no"}, new Foo {Name="yes2"} };
        _fooRepMock.Setup(r=>r.GetFoo()).Returns(fooFromRepository);
    
        var actual = _fooService.FindByNameStartsWith("yes");
    
        Assert.That(actual, Is.EquivalentTo(new [] { fooFromRepository[0], fooFromRepository[2] }));
    }
