    [TestMethod]
    public async Task AllBrandsTest()
    {
        BrandsViewModel viewModel = new BrandsViewModel();
        var task = viewModel.GetBrands();
        Assert.IsTrue(task.Wait(YOUR_TIMEOUT), "failed to load in time");
        Assert.IsTrue(viewModel.Brands.Any(), "no brands");
    }
