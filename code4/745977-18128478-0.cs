    [Test]
    public void Test()
    {
        Mapper.CreateMap<Models.MyModel, Entities.MyEntity>();
        var destination = Mapper.GetAllTypeMaps()
                                .First(t => t.SourceType == typeof(Models.MyModel));
        Assert.AreEqual(typeof (Entities.MyEntity), destination.DestinationType);
    }
