    namespace MVCF1
    {
        using System.Collections.Generic;
        using AutoMapper;
        public class MVCF1Profile : Profile
        {
            public override string ProfileName
            {
                get { return "MVCF1Profile"; }
            }
            protected override void Configure()
            {
                AllowNullDestinationValues = true;
                AllowNullCollections = true;
                CreateMap<API.Driver, Models.Driver>()
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.givenName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.familyName));
                CreateMap<API.DriverStanding, Models.DriverResults>()
                    .ForMember(dest => dest.Driver, opt => opt.MapFrom(src => new List<Models.Driver> { Mapper.Map<API.Driver, Models.Driver>(src.Driver) }))
                    .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.points))
                    .ForMember(dest => dest.Season, opt => opt.Ignore());
                CreateMap<API.StandingsList, Models.DriverResults>()
                    .ForMember(dest => dest.Season, opt => opt.MapFrom(src => src.season))
                    .ForMember(dest => dest.Driver, opt => opt.Ignore())
                    .ForMember(dest => dest.Points, opt => opt.Ignore());
                CreateMap<API.StandingsTable, Models.DriverResults>()
                    .ForMember(dest => dest.Season, opt => opt.Ignore())
                    .ForMember(dest => dest.Driver, opt => opt.Ignore())
                    .ForMember(dest => dest.Points, opt => opt.Ignore());
                CreateMap<API.MRData, Models.DriverResults>()
                    .ForMember(dest => dest.Season, opt => opt.Ignore())
                    .ForMember(dest => dest.Driver, opt => opt.Ignore())
                    .ForMember(dest => dest.Points, opt => opt.Ignore());
                CreateMap<API.RootObject, Models.DriverResults>()
                    .ForMember(dest => dest.Season, opt => opt.Ignore())
                    .ForMember(dest => dest.Driver, opt => opt.Ignore())
                    .ForMember(dest => dest.Points, opt => opt.Ignore());
            }
        } 
    }
