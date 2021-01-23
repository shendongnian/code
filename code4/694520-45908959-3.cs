    static async Task Main(string[] args)
    {
        Task<string> getWebPageTask = GetWebPageAsync("http://msdn.microsoft.com");
        Debug.WriteLine("In startButton_Click before await");
        string webText = await getWebPageTask;
        Debug.WriteLine("Characters received: " + webText.Length.ToString()); 
    }
