    [TestMethod]
    public void BaseMapperWorks()
    {   
        //MapperConfig is my static MapperCongfiguration Class
        MapperConfig.Configure();
        Mapper.AssertConfigurationIsValid();
    }
