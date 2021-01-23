    private async Task CheckUrl()
        {
            List<Task> tasks = new List<Task>();
            string url = GetNextUrl();
            while (!String.IsNullOrEmpty(url))
            {
                tasks.Add(Task.Run(() => CheckWebSite(url)));
                url = GetNextUrl();
            }
            await Task.WhenAll(tasks);
            // All tasks have finished...
        }
