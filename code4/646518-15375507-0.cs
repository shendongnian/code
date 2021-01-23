    static void Main(string[] args)
    {
        var url = "http://somesite.com/bigdownloadfile.zip";
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var getTask = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        Task contentDownloadTask = null;
        var continuation = getTask.ContinueWith((t) =>
        {
            contentDownloadTask = Task.Run(() =>
            {
                var resultStream = t.Result.Content.ReadAsStreamAsync().Result;
                resultStream.CopyTo(File.Create("output.dat"));
            });
            Console.WriteLine("Got {0} headers", t.Result.Headers.Count());
            Console.WriteLine("Blocking after fetching headers, press any key to continue...");
            Console.ReadKey(true);
        });
        continuation.Wait();
        contentDownloadTask.Wait();
        Console.WriteLine("Finished downloading {0} bytes", new FileInfo("output.dat").Length);
        Console.WriteLine("Finished, press any key to exit");
        Console.ReadKey(true);
    }
