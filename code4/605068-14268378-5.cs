    [TestMethod]
    public void TestMethod()
    {
        var configuration1 = new Configuration(new TypeMapFactory(), MapperRegistry.AllMappers());
        var mapper1 = new MappingEngine(configuration1);
        configuration1.CreateMap<User, User>();
        var user = new User() { Name = "John", Age = 42 };
        var mappedUser1 = mapper1.Map<User, User>(user);//maps both Name and Age
        var configuration2 = new Configuration(new TypeMapFactory(), MapperRegistry.AllMappers());
        configuration2.CreateMap<User, User>().ForMember(dest => dest.Age, opt => opt.Ignore());
        var mapper2 = new MappingEngine(configuration2);
        var mappedUser2 = mapper2.Map<User, User>(user);
        Assert.AreEqual(0, mappedUser2.Age);//maps only Name
    }
