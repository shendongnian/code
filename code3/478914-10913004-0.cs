        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string enginePath;
            switch (Path.GetExtension(path).ToLowerInvariant())
            {
                case ".ps1":
                    enginePath = "powershell.exe";
                    break;
                case ".vbs":
                    enginePath = "cscript.exe";
                    break;
                default:
                    throw new ApplicationException("Unknown script type");
            }
            string scriptPath = path;
            Process process = new Process();
            process.StartInfo.FileName = enginePath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
        }
