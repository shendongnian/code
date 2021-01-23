    public class ArticleNewsItemResolver : ValueResolver<Article, ArticleNewsItem>
    {
        protected override ArticleNewsItem ResolveCore(Article source)
        {
            return Mapper.DynamicMap<Article, ArticleNewsItem>(source);
        }
    }
    ...
    CreateMap<Article, ArticleNewsItemDetailsViewModel>()
        .ForMember(src => src.NewsItem, opt => opt.ResolveUsing<ArticleNewsItemResolver>());
