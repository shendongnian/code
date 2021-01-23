    var allowOverrides = true;
    Mapper.CreateMap<Sample1, Sample2>()
        .ForMember(dest => dest.Age,
                   opt => opt.ResolveUsing<NullableIntResolver>()
                   .FromMember(src => src.Age)
                   .ConstructedBy(() => new NullableIntResolver(allowOverrides)))
        .ForMember(dest => dest.Number,
                   opt => opt.ResolveUsing<NullableIntResolver>()
                   .FromMember(src => src.Number)
                   .ConstructedBy(() => new NullableIntResolver(allowOverrides)));
    Mapper.AssertConfigurationIsValid();
