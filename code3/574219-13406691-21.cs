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
                CreateMap<API.StandingsList, Models.DriverResults>()
                    .ForMember(dest => dest.Driver, opt => opt.MapFrom(src => src.DriverStandings.Select(ds => Mapper.Map<API.Driver, Models.Driver>(ds.Driver))))
                    .ForMember(dest => dest.Points, opt => opt.Ignore());
            }
        }
    }
