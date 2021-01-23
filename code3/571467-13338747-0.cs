    public static class AutoMapperConfig
    {
         public static void Configure()
         {
             Mapper.CreateMap<Z, Destination>()
                 .ForMember(dest => dest.A, opt => opt.Ignore())
                 .ForMember(dest => dest.C, opt => opt.Ignore());
             Mapper.CreateMap<Y, Destination>()
                 .ForMember(dest => dest.A, opt => opt.Ignore())
                 .ForMember(dest => dest.E, opt => opt.Ignore())
                 .ForMember(dest => dest.F, opt => opt.Ignore());
             Mapper.CreateMap<X, Destination>()
                 .ForMember(dest => dest.C, opt => opt.Ignore())
                 .ForMember(dest => dest.E, opt => opt.Ignore())
                 .ForMember(dest => dest.F, opt => opt.Ignore());
         }
    }
