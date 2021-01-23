    public class Service : IService
    {
        [RetryOnExceptionAspect(5, typeof(TimeoutException)]
        public void DoSomething()
        {
        }
    }
