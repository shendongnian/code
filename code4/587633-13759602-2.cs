    [Test]
    public void WhenRetievingTitleFromDataStore_ThenDataLayerReturnsTitle() 
    {
        var title = "Title";
        var dataProviderMock = new Mock<IDataProvider>(MockBehavior.Strict);
        dataProviderMock.Setup(x => x.ExecuteMySelectQuery(<parameters>)).Returns(title);
        var dataLayer = new DataLayer(dataProviderMock.Object);
        Assert.That(dataLayer.GetTitle(<myVar>, Is.EqualTo(title));
    }
