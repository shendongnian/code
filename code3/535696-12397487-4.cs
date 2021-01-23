    public class MyApiController : ApiController
    {
        private readonly IQueryProcessor _queryProcessor;
    
        public MyApiController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor
        }
    
        public IEnumerable<MyApiModel> Get
            ([FromUri] string queryParam1, int queryParam2)
        {
            var query = new MyQueryObject
            {
                QueryParam1 = queryParam1,
                QueryParam2 = queryParam2,
            };
            var results = _queryProcessor.Execute(query);
            return Mapper.Map<IEnumerable<MyApiModel>>(results);
        }
    }
