    [Test]
    public void Index_Get_ReturnsViewResult()
    {
        var restClient = MockRepository.GetMock<IRestClient>();
        var controller = new PlanetsController(restClient);
        restClient.Expect(c => c.Get(null)).IgnoreArguments().Return(new PlanetsResponse{ /* some fake Planets */ });
        var viewResult =  controller.Index() as ViewResult;
        Assert.IsNotNull(viewResult);
        // here you can also assert that the Model has the list of Planets you injected...
    }
