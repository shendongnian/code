    string output = "Error";
    Task task = Task.Factory.StartNew(() =>
    {
        System.Threading.Thread.Sleep(2000);
        output = "Complete";
    });
    
    task.Wait();
    Console.WriteLine(output);
