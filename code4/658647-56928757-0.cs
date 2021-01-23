    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
    
        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetStringAsync("http://www.google.com");
            return Ok(result);
        }
    }
