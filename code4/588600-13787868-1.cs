    [Fact]
    public async Task CheckValueSetting()
    {
        var model = new Mock<ISampleModel>();
        model.Setup(x => x.GetSomeIntegerValue()).Returns(5);
        SampleVm viewModel;
        // Note: you should await this if Run returns Task.
        //  (the compiler will warn you if this is the case)
        GeneralThreadAffineContext.Run(async () =>
        {
            viewModel = new SampleVm(model.Object);
            await viewModel.SetDependencyProperty();
        });
        Assert.Equal(5, viewModel.SampleDependencyProperty);
    }
