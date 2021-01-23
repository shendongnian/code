    public async Task<string> GetValuesAsync() {           
        using (var httpClient = new HttpClient()) {
            var response = await httpClient
                .GetAsync("http://www.google.com")
                .ConfigureAwait(continueOnCapturedContext: false);
            // And now we're on the thread pool thread.
            // This "await" will capture the current SynchronizationContext...
            var html = await GetStringAsync();
            // ... and resume it here.
            // But it's not the UI SynchronizationContext.
            // It's the ThreadPool SynchronizationContext.
            // So we're back on a thread pool thread here.
            // So this will raise an exception.
            html += "Hey...";
            Foo.Text = html;
            return html;
        }
    }
