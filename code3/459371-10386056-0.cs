        public static void RegisterDll(string filePath)
        {
            string fileinfo = String.Format(@"/s ""{0}""", filePath);
            Process process = new Process();
            process.StartInfo.FileName = "regsvr32.exe";
            process.StartInfo.Arguments = fileinfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            process.Close();
        }
