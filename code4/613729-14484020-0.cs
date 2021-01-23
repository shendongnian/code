    private static void DelayExecution(Action action, TimeSpan delay)
    {
        TimeSpan start = DateTime.Now.TimeOfDay;
        Thread t = new Thread(() =>
        {
            while (DateTime.Now.TimeOfDay < start.Add(delay))
            {
                //Block
            }
            action.Invoke();
        });
        t.Start();
    }
    private static void Main(string[] args)
    {
        DelayExecution(() => Console.WriteLine("Delayed Execution"), TimeSpan.FromSeconds(1));
        Console.ReadLine();
    }
