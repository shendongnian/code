    private static Dictionary<string, string> CaptureBuildEnvironment(
        int vsVersion, 
        string architectureName
        )
    {
        // assume the helper is in the same directory as this exe
        string myExeDir = Path.GetDirectoryName(
            Assembly.GetExecutingAssembly().Location
            );
        string envCaptureExe = Path.Combine(myExeDir, "envcapture.exe");
        string vsToolsVariableName = String.Format("VS{0}COMNTOOLS", vsVersion);
        string envSetupScript = Path.Combine(
            Environment.GetEnvironmentVariable(vsToolsVariableName),
            @"..\..\VC\vcvarsall.bat"
            );
        using (Process envCaptureProcess = new Process())
        {
            envCaptureProcess.StartInfo.FileName = "cmd.exe";
            // the /s and the extra quotes make sure that paths with
            // spaces in the names are handled properly
            envCaptureProcess.StartInfo.Arguments = String.Format(
                "/s /c \" \"{0}\" {1} && \"{2}\" \"",
                envSetupScript,
                architectureName,
                envCaptureExe
                );
            envCaptureProcess.StartInfo.RedirectStandardOutput = true;
            envCaptureProcess.StartInfo.RedirectStandardError = true;
            envCaptureProcess.StartInfo.UseShellExecute = false;
            envCaptureProcess.StartInfo.CreateNoWindow = true;
            envCaptureProcess.Start();
            // read and discard standard error, or else we won't get output from
            // envcapture.exe at all
            envCaptureProcess.ErrorDataReceived += (sender, e) => { };
            envCaptureProcess.BeginErrorReadLine();
            string outputString = envCaptureProcess.StandardOutput.ReadToEnd();
            // vsVersion < 110 prints out a line in vcvars*.bat. Ignore 
            // everything before the first '<'.
            int xmlStartIndex = outputString.IndexOf('<');
            if (xmlStartIndex == -1)
            {
                throw new Exception("No environment block was captured");
            }
            XElement documentElement = XElement.Parse(
                outputString.Substring(xmlStartIndex)
                );
            Dictionary<string, string> capturedVars 
                = new Dictionary<string, string>();
            foreach (XElement variable in documentElement.Elements("Variable"))
            {
                capturedVars.Add(
                    (string)variable.Attribute("Name"),
                    (string)variable
                    );
            }
            return capturedVars;
        }
    }
