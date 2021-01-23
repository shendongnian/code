    public static void PrintMe(object obj)
    {
        Task task = new Task(() =>
        {
            Console.WriteLine(obj.ToString());
        });
        obj = "Surprise";        
        task.Start();
    }
