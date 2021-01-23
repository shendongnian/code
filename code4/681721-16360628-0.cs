    public class AutoMapperConfig
    {
        public static void CreateMaps()
        {
            // Feed domain / view model mappings
            Mapper.CreateMap<FeedViewModel, Feed>()
            Mapper.CreateMap<Feed, FeedViewModel>();            
        }
    }
