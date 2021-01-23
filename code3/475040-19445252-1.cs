     class SomeChecker
    {
        private const int ThreadCount=20;
        private CountdownEvent _countdownEvent;
        private SemaphoreSlim _throttler;
        public Task Check(IList<string> urls)
        {
            _countdownEvent = new CountdownEvent(urls.Count);
            _throttler = new SemaphoreSlim(ThreadCount); 
            return Task.Run( // prevent UI thread lock
                async  () =>
                {
                    foreach (var url in urls)
                    {
                        // do an async wait until we can schedule again
                        await _throttler.WaitAsync();
                        await ProccessUrl(url);
                    }
                    _countdownEvent.Wait(); //instead of await Task.WhenAll(allTasks);
                }
                );
        }
        private async Task ProccessUrl(string url)
        {
            try
            {
                var page = await new WebClient().DownloadStringTaskAsync(new Uri(url)); 
                ProccessResult(page);
            }
            finally
            {
                _throttler.Release();
                _countdownEvent.Signal();
            }
        }
        private void ProccessResult(string page){/*....*/}
    }
