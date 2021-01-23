    protected override void Configure()
    {
        Mapper.CreateMap<API.Driver, Models.Driver>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.givenName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.familyName));
        Mapper.CreateMap<API.DriverStanding, Models.DriverResults>()
            .ForMember(dest => dest.Driver, opt => opt.MapFrom(src => new List<Models.Driver> { Mapper.Map<API.Driver, Models.Driver>(src.Driver)}))
            .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.points))
            .ForMember(dest => dest.Season, opt => opt.Ignore());
        Mapper.CreateMap<API.StandingsList, Models.DriverResults>()
            .ForMember(dest => dest.Season, opt => opt.MapFrom(src => src.season))
            .ForMember(dest => dest.Driver, opt => opt.Ignore())
            .ForMember(dest => dest.Points, opt => opt.Ignore());
    }
