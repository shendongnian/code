    namespace StrategyPattern
    {
        class Program
        {
            static void Main(string[] args)
            {
                var context = new SocialContext();
            context.SetProvider(new FacebookProvider()); //switch which provider you want to use
            context.AddComment(new Comment()
                {
                    Message = "Heres my Comment!"
                });
        }
    }
    //providers
    public interface IProvider
    {
        void AddComment(Comment comment);
        void PostArticle(Article article);
    }
    public class FacebookProvider :IProvider
    {
        public void AddComment(Comment comment)
        {
            //facebook implementation of "AddComment"
        }
        public void PostArticle(Article article)
        {
            //facebook implementation of "PostArticle"
        }
    }
    public class TwitterProvider : IProvider
    {
        public void AddComment(Comment comment)
        {
            //twitter implementation of "AddComment"
        }
        public void PostArticle(Article article)
        {
            //twitter implementation of "PostArticle"
        }
    }
    public class Article
    {
        public string Content { get; set; }
    }
    
    public class Comment
    {
        public String Message { get; set; }
    }
    //context to use the providers
    
    public class SocialContext
    {
        private IProvider _provider;
        public void SetProvider(IProvider provider)
        {
            _provider = provider;
        }
        public IProvider GetProvide { get { return _provider; } }
        public void AddComment(Comment comment)
        {
            _provider.AddComment(comment);
        }
        public void PostArticle(Article article)
        {
            _provider.PostArticle(article);
        }
    }
