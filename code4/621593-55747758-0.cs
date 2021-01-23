            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, DestinationBase>()
                    .ForMember(dest => dest.Test3, opt => opt.MapFrom(src => src.Test))
                    .IncludeAllDerived();
                cfg.CreateMap<Source, DestinationDerived1>()
                    .ForMember(dest => dest.Test4, opt => opt.MapFrom(src => src.Test2));
                cfg.CreateMap<Source, DestinationDerived2>()
                      .ForMember(dest => dest.Test5, opt => opt.MapFrom(src => src.Test2));
            });
            var mapper = config.CreateMapper();
            var source = new Source { Test = "SourceTestProperty", Test2 = "SourceTest2Property" };
            var d1 = mapper.Map<DestinationDerived1>(source);
            var d2 = mapper.Map<DestinationDerived2>(source);
            Assert.Equal("SourceTestProperty", d1.Test3);
            Assert.Equal("SourceTest2Property", d1.Test4);
            Assert.Equal("SourceTestProperty", d2.Test3);
            Assert.Equal("SourceTest2Property", d2.Test5);
