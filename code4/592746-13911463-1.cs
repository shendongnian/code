    private static Thread worker;
    
    public static void Init(string testing)
    {
        // passing anonymous method, which will capture parameter
        worker = new Thread(() => Work(testing));
        worker.Start();
    }
    
    public static void Work(string testing)
    {
        string result = testing;
    }
---
    private static Thread worker;
    
    public static void Init(string testing)
    {
        // passing PrametrizedThreadStart delegate
        worker = new Thread(Work);
        worker.Start(testing); // passing parameter
    }
    
    // PrametrizedThreadStart delegate accepts object as parameter
    public static void Work(object testing)
    {
        string result = (string)testing;
    }
