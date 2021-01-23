    [Test]
    public void X()
    {
        A objA = new A();
        var x = FooEventHandler(objA);
        Assert.IsInstanceOf<A>(x);
        Assert.AreEqual("updated", (x as A).MyProperty);
        B objB = new B();
        var y = FooEventHandler(objB);
        Assert.IsInstanceOf<B>(y);
        Assert.AreEqual("updated", (y as B).MyProperty);
        C objC = new C();
        var z = FooEventHandler(objC);
        Assert.IsInstanceOf<C>(z);
        Assert.AreEqual("updated", (z as C).MyProperty);
        D objD = new D();
        Assert.Throws<RuntimeBinderException>(() => FooEventHandler(objD));
    }
    class D {}
