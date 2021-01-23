    static async Task<int> SumPageSizesAsync(string[] uris)
    {
        int total = 0;
        var wc = new WebClient();
        var tasks = new List<Task<byte[]>>();
        foreach (var uri in uris)
        {
            tasks
              .Add(wc.DownloadDataTaskAsync(uri).ContinueWith(() => { total += data.Length;
            }));
        }
        Task.WaitAll(tasks);
        return total;
    }
