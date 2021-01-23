    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    // support halting a workflow and waiting for a finish request
    public class MockWorker
    {
        private readonly DateTime? _end;
        private volatile bool _shouldStop;
        public MockWorker(int? timeoutInMilliseconds = null)
        {
            if (timeoutInMilliseconds.HasValue) _end = DateTime.Now.AddMilliseconds(timeoutInMilliseconds.Value);
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        public async Task DoWorkAsync()
        {
            while (!_shouldStop)
            {
                await Task.Delay(100);
                if (_end.HasValue && _end < DateTime.Now) throw new AssertFailedException("Timeout");
            }
        }
        public async Task<T> DoWorkAsync<T>(T bulkExecutor)
        {
            await DoWorkAsync();
            return bulkExecutor;
        }
    }
