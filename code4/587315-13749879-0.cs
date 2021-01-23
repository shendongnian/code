    class Program
    {
        static void Main(string[] args)
        {
            var startInfo = new ProcessStartInfo("notepad.exe");
            var process = Process.Start(startInfo);
            process.WaitForExit();
            //Do whatever you need to do here
            Console.Write("Notepad Closed");
            Console.ReadLine();
        }
    }
