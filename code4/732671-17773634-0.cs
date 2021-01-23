    public void TestMethod1()
    {
    var list = new List<Foo> { new Foo { Name = "Item" } };
    Assert.IsNotNull(list as IList);
    Assert.IsNotNull(list[0] as Foo);
    Assert.IsNotNull(list[0] as IBar);
    Assert.IsNotNull(list as IList<Foo>);
    Assert.IsNotNull((IList<Foo>)list);
    }
