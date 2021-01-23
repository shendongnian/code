    public interface IContentService
    {
        Categories GetCategories();
    }
    public class CachingContentSerice : IContentService
    {
        private readonly IContentService _inner;
        public CachingContentSerice(IContentService _inner)
        {
            _inner = inner;
        }
        public Categories GetCategories()
        {
            string key = "GetCategories";
            if (!CacheHandler.ContainsKey(key))
            {
                Catogories categories = _inner.GetCategories();
                CacheHandler.InsertToCache(key, categories);
            }
            return CacheHandler.GetCache(key);
        }
    }
    public class ContentSerice : IContentService
    {
        public Categories GetCategories()
        {
            return RequestHelper.MakeRequest("get_category_index")["categories"];
        }
    }
