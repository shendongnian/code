    private static string Send(int id)
    {
        Task<HttpResponseMessage> responseTask = client.GetAsync("aaaaa");
        Task<string> result;
        responseTask.ContinueWith(x => result = Print(x));
        result.Wait();
        responseTask.Wait(); // There's likely a better way to wait for both tasks without doing it in this awkward, consecutive way.
        return result.Result;
    }
    private static Task<string> Print(Task<HttpResponseMessage> httpTask)
    {
        Task<string> task = httpTask.Result.Content.ReadAsStringAsync();
        string result = string.Empty;
        task.ContinueWith(t =>
        {
            Console.WriteLine("Result: " + t.Result);
            result = t.Result;
        });
        return task;
    }
