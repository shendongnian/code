    private static string Send(int id)
    {
        Task<HttpResponseMessage> responseTask = client.GetAsync("aaaaa");
        string result = string.Empty;
        Task continuation = responseTask.ContinueWith(x => result = Print(x));
        continuation.Wait();
        return result;
    }
    private static string Print(Task<HttpResponseMessage> httpTask)
    {
        Task<string> task = httpTask.Result.Content.ReadAsStringAsync();
        string result = string.Empty;
        Task continuation = task.ContinueWith(t =>
        {
            Console.WriteLine("Result: " + t.Result);
            result = t.Result;
        });
        continuation.Wait();  
        return result;
    }
