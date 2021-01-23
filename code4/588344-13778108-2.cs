    static void m()
    {
        var proxy = new YourServiceClient();
        proxy.GetMessagesCompleted += proxy_GetMessagesCompleted;
        proxy.GetMessagesAsync();
    }
    static void proxy_GetMessagesCompleted(object sender, GetMessagesCompletedEventArgs e)
    {
        var proxy = (IDisposable)sender;
        proxy.Dispose(); //actual code to close properly is more complex
        if (e.Error != null)
        {
            // do something about this
        }
        var result = e.Result;
        Console.WriteLine(result);
    }
