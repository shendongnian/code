    DateTime.UtcNow.ToString("o");
    // "2012-02-08T19:19:38.5767158Z"
    new DateTime(DateTime.UtcNow.Ticks).ToString("o");
    // "2012-02-08T19:19:38.5767158"
    new DateTime(DateTime.Now.Ticks).ToString("o");
    // "2012-02-08T14:19:38.5767158"
