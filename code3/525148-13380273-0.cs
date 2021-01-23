    internal bool FillSingleRow()
        {
            return RunTest("Stryktipset_singleRow.sikuli");
        }
    public static bool RunTest(string sikuliTest)
        {
            var sikuliHome = Environment.GetEnvironmentVariable("SIKULI_HOME");
            var execDir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            for (var i = 0; i < 2; i++)
            {
                var tempDir = execDir.Parent;
                if (tempDir != null)
                {
                    execDir = tempDir;
                }
            }
            Sikuli.StartInfo.UseShellExecute = false;
            Sikuli.StartInfo.RedirectStandardError = true;
            Sikuli.StartInfo.RedirectStandardInput = true;
            Sikuli.StartInfo.RedirectStandardOutput = true;
            Sikuli.StartInfo.WorkingDirectory = sikuliHome;
            Sikuli.StartInfo.CreateNoWindow = true;
            Sikuli.StartInfo.Arguments = "-jar sikuli-script.jar -s " + '\u0022' + execDir.FullName + "\\Sikuli\\" + sikuliTest + '\u0022';
            Sikuli.StartInfo.FileName = "java.exe";
            Sikuli.Start();
            var so = Sikuli.StandardOutput;
            var se = Sikuli.StandardError;
            var error = se.ReadToEnd();
            if (error != string.Empty)
            {
                TestLog.Write(error);
                return false;
            }
            else
            {
                return true;
            }
        }
