    class Program
    {
        public static void Main(string[] args)
        {
            Process process = new Process();
            process.StartInfo.FileName = args[0];
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }
    }
