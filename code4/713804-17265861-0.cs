    public void TestMethod1()
        {
            Mapper.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
            Mapper.CreateMap<string, Type>().ConvertUsing(new StringTypeConverter());
            Mapper.CreateMap<string, int>().ConvertUsing(new StringIntConverter());
            Mapper.CreateMap<Source, Destination>();
            var destination =
            Mapper.Map<Source, Destination>(
            new Source { Value1 = "15", Value2 = "01/01/2000", Value3 = "System.String" },
                options => options.ConstructServicesUsing(type => new SourceDestinationTypeConverter())
            );
            Assert.AreEqual(destination.Value2.Year, 2000);
        }
