    interface IActionResult
    {
        bool Success { get; set; }
        string FailureMessage { get; set; }
    }
    
    public static void GlobalTryCatch<T>(Action action, T obj)
        where T : IActionResult
    {
        // ...
    }
