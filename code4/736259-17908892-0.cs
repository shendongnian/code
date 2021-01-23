    Console.WriteLine("Running");
    Process pr = new Process();
    pr.StartInfo.FileName = "Notepad.exe";
    pr.StartInfo.Arguments = "test.dat";
    pr.Start();
    while (pr.HasExited == false)
        if ((DateTime.Now.Second % 5) == 0)
        { // Show a tick every five seconds.
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
