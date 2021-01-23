    public class ArticleService : SalesDb
    {
        public IEnumerable<ArticleDto> SelectAll()
        {
            using (IDbConnection connection = OpenConnection())
            {
                var articles = connection.Query<ArticleDto>("SELECT * FROM Articles");
    
                return articles;
            }
        }
    }
