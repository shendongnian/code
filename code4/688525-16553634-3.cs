    public class ModelSearchApiController : ApiController
    {
        public List<Model> Get([FromUri] SearchModel search)
        {
            return new List<Model>
            {
                new Model { PageIndex = search.PageIndex, PageSize = search.PageSize, Terms = search.Terms }
            };
        }
        public List<Model> Post(SearchModel search)
        {
            return new List<Model>
            {
                new Model { PageIndex = search.PageIndex, PageSize = search.PageSize, Terms = search.Terms }
            };
        }
    }
    public class Model
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, object> Terms { get; set; }
    }
    public class SearchModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, object> Terms { get; set; }
    }
