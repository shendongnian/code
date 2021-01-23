    CreateMap<FixtureDTO, Fixture>()
            .ForMember(dest => dest.FixtureId,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.AwayTeam,
                       opt => opt.MapFrom(src => new Team
                                                     {
                                                         TeamName = src.AwayTeamName
                                                     }))
            .ForMember(dest => dest.HomeTeam,
                       opt => opt.MapFrom(src => new Team
                                                     {
                                                         TeamName = src.HomeTeamName
                                                     }));
