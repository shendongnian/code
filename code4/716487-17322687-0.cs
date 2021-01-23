    class B
    {
        public B(string key, C anotherDependency)
        {
            this.Key = key;
        }
        public string Key { get; private set; }
    }
    class C
    {
        public string Value { get { return "C.Value"; } }
    }
    [TestMethod]
    public void test()
    {
        var cb = new ContainerBuilder();
        cb.RegisterType<B>().WithParameter(
            (prop, context) => prop.Name == "key",
            (prop, context) => context.Resolve<C>().Value);
        cb.RegisterType<C>();
        var b = cb.Build().Resolve<B>();
        Assert.AreEqual("C.Value", b.Key);
    }
