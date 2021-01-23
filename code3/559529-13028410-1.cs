    static void Main(string[] args)
    {
        Console.WriteLine("About to call DNS");
        var worker = new BackgroundWorker();
        worker.DoWork += worker_DoWork;
        worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        worker.RunWorkerAsync("74.125.237.112");
        Console.Read();
    }
    static void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        var host = new IPHostEntry { AddressList = new[] { IPAddress.Parse((string)e.Argument) } };
        var result = Dns.GetHostEntry(host.AddressList[0]);
        e.Result = result.HostName;
    }
    static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // You could set your UI control here like label1.text = (string)e.Result
        Console.WriteLine((string)e.Result);
    }
