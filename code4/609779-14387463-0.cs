    public void Test()
    {
        Mock<Outer> omock = new Mock<Outer>();
        Console.WriteLine("Outer");
        omock.SetupProperty(m => m.Inner.Prop, -1);
        omock.Object.Inner.PropChanged += InnerPropChanged;
        Mock.Get(omock.Object.Inner)
            .Raise(m => m.PropChanged += null, EventArgs.Empty);
    }
