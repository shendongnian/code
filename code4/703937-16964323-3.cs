    public sealed class MyCpuActivity : AsyncTaskCodeActivity<int>
    {
        protected override Task<int> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Task.Run(() => 13);
        }
    }
