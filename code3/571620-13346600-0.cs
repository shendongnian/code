    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process process = new Process();
                process.StartInfo.FileName = "notepad";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
    
                process.Start();
            }
        }
    }
