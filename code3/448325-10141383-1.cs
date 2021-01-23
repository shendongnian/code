    public class ArticleMapping : ClassMap<Article>
    {
        public ArticleMapping()
        {
            Id(x => x.ArticleId).GeneratedBy.Identity();
            Map(x => x.Description).UniqueKey("Article_Description_Unique");
        }
    }
