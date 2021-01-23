    [TestMethod]
    public async Task TestAsyncCommand()
    {
        var viewModel = new ViewModel();
            
        Assert.IsFalse(viewModel.Executed);
        await viewModel.AsyncCommand.Execute();
        Assert.IsTrue(viewModel.Executed);
    }
