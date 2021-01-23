    class Program
    {
        private static NamedPipeClientStream _pipeClient;
        static void Main(string[] args)
        {
            //Current application is a Win32 application without any console window
            var processStartInfo = new ProcessStartInfo("echoserver.exe");
            Process serverProcess = new Process {StartInfo = processStartInfo};
            serverProcess.Start();
            _pipeClient = new NamedPipeClientStream(".", @"Com.MyDomain.EchoServer.PipeServer", PipeDirection.Out, PipeOptions.None);
            _pipeClient.Connect();
            StreamWriter writer = new StreamWriter(_pipeClient) {AutoFlush = true};
            Console.SetOut(writer);
            
            Console.WriteLine("Testing");
            //Do rest of the work. 
            //Also detect that the server has terminated (serverProcess.HasExited) and then close the _pipeClient
            //Also remember to terminate the server process when current process exits, serverProcess.Kill();
            while (true)
                continue;
        }
    }
