    [Test]
    public void TestLoadData()
    {
        _viewModel.LoadData(_context);
        Assert.IsNotEmtpy(_viewModel.Measurements);
    }
