    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private ISession _session;
        public ArticleRepository(ISession session) : base(session)
        {
            _session = session;
        }
        public List<Article> GetByDescription(string description)
        {
            return _session
                .GetNamedQuery("ArticlesByDescription")
                .SetString("Description", description)
                .List<Article>().ToList();
        }
    }
