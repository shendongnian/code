    public interface IMyService {}
    public static class MyServiceBuilder
    {
        public static IMyService GetMyService()
        {
            //Most likely your real implementation has the service stored somewhere
            return new MyService();
        }
        private sealed class MyService : IMyService
        {
            //...
        }
    }
