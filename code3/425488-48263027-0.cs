    [Route("api/[controller]/[action]")]
    public class SomeController : Controller
    {
        public SomeValue GetItems(CustomParam parameter) { ... }
        public SomeValue GetChildItems(CustomParam parameter, SomeObject parent) { ... }
    }
