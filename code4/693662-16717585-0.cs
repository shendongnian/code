    public class ArticleMap : ClassMap<Article>
    {
       public ArticleMap()
       {
          Id(x => x.Id);
          Map(x => x.Title);
          HasOne(x => x.Content).Cascade.All();
    }
    public class ContentMap : ClassMap<Content>
    {
        public ContentMap()
        {
          Id(x => x.Id).GeneratedBy.Foreign("Article");
          HasOne(x => x.Article).Constrained().ForeignKey();
          Map(x => x.content);
          Map(x => x.remarks);
        }
    }
