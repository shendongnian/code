    internal class StartNewDemo
    {
        public static void Main(string[] args)
        {
            Mapper.CreateMap<IList<Article>, ViewAllArticles>()
                .ForMember(map => map.ActiveArticles, opt => opt.MapFrom(x => x.Where(y => y.IsActive)))
                .ForMember(map => map.InactiveArticles, opt => opt.MapFrom(x => x.Where(y => !y.IsActive)));
        	
        	var list = new List<Article>() { new Article { IsActive=true }, new Article { IsActive = false } };
        	var result = Mapper.Map<List<Article>, ViewAllArticles>( list );
        }
    }
