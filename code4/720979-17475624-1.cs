    /// <summary>
    ///     Initialize the AutoMapper mappings for the solution.
    ///     http://automapper.codeplex.com/
    /// </summary>
    private static void CreateAutoMapperMaps()
    {
        AutofacRegistrations.RegisterDaoFactory();
        ILifetimeScope scope = AutofacRegistrations.Container.BeginLifetimeScope();
        var daoFactory = scope.Resolve<IDaoFactory>();
        Mapper.CreateMap<Error, ErrorDto>()
              .ReverseMap();
        IPlaylistItemDao playlistItemDao = daoFactory.GetPlaylistItemDao();
        IPlaylistDao playlistDao = daoFactory.GetPlaylistDao();
        IStreamDao streamDao = daoFactory.GetStreamDao();
        IUserDao userDao = daoFactory.GetUserDao();
        Mapper.CreateMap<Playlist, PlaylistDto>()
              .ReverseMap()
              .ForMember(playlist => playlist.FirstItem,
                         opt => opt.MapFrom(playlistDto => playlistItemDao.Get(playlistDto.FirstItemId)))
              .ForMember(playlist => playlist.NextPlaylist,
                         opt => opt.MapFrom(playlistDto => playlistDao.Get(playlistDto.NextPlaylistId)))
              .ForMember(playlist => playlist.PreviousPlaylist,
                         opt => opt.MapFrom(playlistDto => playlistDao.Get(playlistDto.PreviousPlaylistId)))
              .ForMember(playlist => playlist.Stream,
                         opt => opt.MapFrom(playlistDto => streamDao.Get(playlistDto.StreamId)));
        Mapper.CreateMap<PlaylistItem, PlaylistItemDto>()
              .ReverseMap()
              .ForMember(playlistItem => playlistItem.NextItem,
                         opt => opt.MapFrom(playlistItemDto => playlistItemDao.Get(playlistItemDto.NextItemId)))
              .ForMember(playlistItem => playlistItem.PreviousItem,
                         opt => opt.MapFrom(playlistItemDto => playlistItemDao.Get(playlistItemDto.PreviousItemId)))
              .ForMember(playlistItem => playlistItem.Playlist,
                         opt => opt.MapFrom(playlistItemDto => playlistDao.Get(playlistItemDto.PlaylistId)));
        Mapper.CreateMap<ShareCode, ShareCodeDto>().ReverseMap();
        Mapper.CreateMap<Stream, StreamDto>()
              .ReverseMap()
              .ForMember(stream => stream.User,
                         opt => opt.MapFrom(streamDto => userDao.Get(streamDto.UserId)))
              .ForMember(stream => stream.FirstPlaylist,
                         opt => opt.MapFrom(streamDto => playlistDao.Get(streamDto.FirstPlaylistId)));
        Mapper.CreateMap<User, UserDto>().ReverseMap();
        Mapper.CreateMap<Video, VideoDto>().ReverseMap();
        Mapper.AssertConfigurationIsValid();
    }
