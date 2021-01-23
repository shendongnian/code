    string batFileName = "dxdiag.bat";
    string programName = Assembly.GetExecutingAssembly().GetName().Name;
    using (Stream input = Assembly.GetExecutingAssembly().GetManifestResourceStream(programName + "." + batFileName))
    {
        using (TextReader tr = new StreamReader(input))
        {
            File.WriteAllText(batFileName, tr.ReadToEnd());
        }
    }
            
    Process proc = new Process();
    proc.EnableRaisingEvents = true;
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.FileName = batFileName;
    proc.StartInfo.CreateNoWindow = true;
    proc.Start();
    proc.WaitForExit();
    proc.Close();
