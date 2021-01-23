    class Program
    {
        static void Main(string[] args)
        {
            Process compiler = new Process();
            compiler.StartInfo.FileName = @"c:\YourPath\Handle.exe";
            compiler.StartInfo.UseShellExecute = false;
            compiler.StartInfo.RedirectStandardOutput = true;
            compiler.Start();
            string line = "";
            int counter = 0;
            string currentProcess = "";
            while ((line = compiler.StandardOutput.ReadLine()) != null)
            {
                // skipping application info
                if (++counter > 6)
                {
                    if (!" -".Contains(char.Parse(line.Substring(0, 1))))
                    {
                        currentProcess = line;
                    }
                    else if ((new[] { ".avi", ".mkv", ".mpg", ".mp4", ".wmv" })
                        .Contains(line.ToLower().Substring(line.Length - 4)))
                    {
                        Console.WriteLine(currentProcess);
                    }
                }
            }
            compiler.WaitForExit();
            Console.ReadLine();
        }
    }
