    public class ValuesController : ApiController
    {
        private readonly IValueService _valueService;
        public ValuesController(IValueService valueService)
        {
            _valueService = valueService;
        }
        public string[] Get()
        {
            return _valueService.GetValues();
        }
        public string Get(int id)
        {
            return _valueService.GetValue(id);
        }
    }
