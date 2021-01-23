    public class ValuesController : ApiController
    {
        // Synchronous
        public IEnumerable<string> Get()
        {
            Thread.Sleep(1000);
            return new string[] { "value1", "value2" };
        }
        // Asynchronous
        public async Task<IEnumerable<string>> Get(int id)
        {
            await Task.Delay(1000);
            return new string[] { "value1", "value2" };
        }
    }
