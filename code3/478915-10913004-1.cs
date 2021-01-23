        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string parameter = Console.ReadLine();
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
            process.StartInfo.Arguments = string.Format("{0} {1}", scriptPath, parameter);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();
        }
