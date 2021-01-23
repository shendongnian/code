    [Test]
    public void PropertyChangeTest()
    {
        var viewModel = new ViewModel();
        var args = new List<PropertyChangedEventArgs>();
        viewModel.PropertyChanged += (o, e) => args.Add(e);
        viewModel.ThreadId = "[11]";
        Assert.AreEqual("ThreadId",args.Single().PropertyName);
    }
