    [ImportMany(typeof(IInterfaceToCompose))]
    public IInterfaceToCompose ComposedItems { get; set; }
    [Test]
    public void WhenComposingTheComposedItems_ShouldLoadExportedTypes()
    {
        Load("testPath", YourContainer);
        Assert.AreEqual(2, ComposedItems.Count());
    }
