    public sealed class MyActivity : AsyncTaskCodeActivity<int>
    {
        protected override async Task<int> ExecuteAsync(AsyncCodeActivityContext context)
        {
            await Task.Delay(100);
            return 13;
        }
    }
