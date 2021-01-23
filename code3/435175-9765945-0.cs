    public class ArticleRepository
    {
        public void Save(Article article)
        {
            // Article is already in a correct state
            // (thanks to no public setters)
    
            var dbEntity = new ArticleEntity();
            Mapper.Map(article, dbEntity);
            _dbContext.Save(dbEntity);
        }
    }
