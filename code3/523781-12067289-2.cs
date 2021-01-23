    //Arrange
    var configStore = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.AllMappers());
    configStore.CreateMap<SqlDataReaderMock, Destination>()
        .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src["tyto"] != null
                                                                            ? src["tyto"].ToString()
                                                                            : String.Empty));
    var _mappingEngine = new MappingEngine(configStore);
    
    //Act
    var result = _mappingEngine.Map<Destination>(new SqlDataReaderMock());
    
    //Assert
    Assert.AreEqual("otyt", result.Name);
    class Destination
    {
        public string Name { get; set; }
    }
    
    class SqlDataReaderMock
    {
        public string this[string value]
        {
            get
            {
                return new string(value
                                        .ToCharArray()
                                        .Reverse()
                                        .ToArray());
            }
        }
    }
