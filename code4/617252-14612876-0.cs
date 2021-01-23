    public class MyController : ApiController
    {
        public Task<string> PostAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return "populate me with any type and data, but change the type in the response signature.";
            });
        }
    }
