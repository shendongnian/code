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
