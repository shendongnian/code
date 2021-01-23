    var mock = new Mock<IRetrieveListService>();
    mock.Setup(m => m.RetrieveList(It.IsAny<CollectionPager>()))
        .Callback<CollectionPager>(p =>
                                        {
                                            p.List.Add("testItem1");
                                            p.List.Add("testItem2");
                                        });
    var sut = new OtherService(mock.Object);
    sut.SomeMethodToTest();
