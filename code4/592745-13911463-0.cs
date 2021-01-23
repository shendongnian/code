    private static Thread worker;
    
    public static void Init(string testing)
    {
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
        worker = new Thread(Work);
        worker.Start(testing);
    }
    
    public static void Work(object testing)
    {
        string result = (string)testing;
    }
