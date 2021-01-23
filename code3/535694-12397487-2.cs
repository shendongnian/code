    public class MyMvcController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
    
        public MyMvcController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor
        }
    
        public ViewResult Index(string queryParam1, int queryParam2)
        {
            var query = new MyQueryObject // this DTO implements IQuery<TResult>
            {
                QueryParam1 = queryParam1,
                QueryParam2 = queryParam2,
            };
            var results = _queryProcessor.Execute(query);
            var models = Mapper.Map<IEnumerable<MyViewModel>>(results);
            return View(models);
        }
    }
