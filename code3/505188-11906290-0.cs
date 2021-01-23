    //This is the POCO entity that we will be storing into Raven
    public class Article
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
    //This is the IndexCreationTask that builds the index
    public class Article_Text : AbstractIndexCreationTask<Article>
    {
        public Article_Text()
        {
            Map = articles => from article in articles select new { article.Text };
        }
    }
    static class Program
    {
        static void Main()
        {
            var ravenIntroArticle = new Article()
            {
                Text = "RavenDB fits into a movement that is called ...",
                Title = "RavenDB Introduction",
            };
            var csharpUsingArticle = new Article()
            {
                Text = "The full value of the C# using statement ...",
                Title = "Your Friend the C# Using Statement",
            };
            var nutsAndProteinArticle = new Article()
            {
                Text = "Nuts are a great source of protein ...",
                Title = "Nuts and Protein",
            };
            using ( IDocumentStore documentStore = new DocumentStore { Url = "http://rtest01:8081" }.Initialize() )
            {
                // This is the static call to create the index
                IndexCreation.CreateIndexes( typeof( Article_Text ).Assembly, documentStore );
                using ( IDocumentSession session = documentStore.OpenSession() )
                {
                    session.Store( ravenIntroArticle ); // no more exceptions here!
                    session.Store( csharpUsingArticle );
                    session.Store( nutsAndProteinArticle );
                    session.SaveChanges();
                }
            }
        }
    }
