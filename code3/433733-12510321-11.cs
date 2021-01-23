    public class IdeaByBodyOrTitle : AbstractIndexCreationTask<Idea, IdeaByBodyOrTitle.IdeaSearchResult>
    {
        public class IdeaSearchResult
        {
            public string Query;
            public Idea Idea;
        }
    
        public IdeaByBodyOrTitle()
        {
            Map = ideas => from idea in ideas
                           select new
                               {
                                   Query = new object[] { idea.Title, idea.Body },
                                   idea
                               };
        }
    }
    
    var result = session.Query<IdeaByBodyOrTitle.IdeaSearchResult, IdeaByBodyOrTitle>()
                        .Search(x => x.Query, wildquery, 
                                escapeQueryOptions: EscapeQueryOptions.AllowAllWildcards,
                                options: SearchOptions.And)
                        .As<Idea>();
