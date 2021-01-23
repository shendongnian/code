    UninstallExisting(GetInstalledAppUri()); // This is how it's called
    //This is the two method's implementation
    
            static string silverlightOutOfBrowserFolder = 
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) 
    + @"\Microsoft\Silverlight\OutOfBrowser";
    private static string GetInstalledAppUri()
        {
            string xapFolderPath = Path.Combine(silverlightOutOfBrowserFolder, GetXapFolder());
            string[] lines = File.ReadAllLines(Path.Combine(xapFolderPath, "metadata"), Encoding.Unicode);
            string finalAppUriLine = lines.First(i => i.Contains("FinalAppUri="));
            return "\"" + finalAppUriLine.Replace("FinalAppUri=", "") + "\"";
        }
        private static string GetXapFolder()
        {
            string AppXapFolder = "";
            foreach (var dir in Directory.GetDirectories(silverlightOutOfBrowserFolder))
            {
                if (dir.Contains("AppName"))
                {
                    AppXapFolder = dir;
                }
            }
            return AppXapFolder ;
        }
    private static string silverlightExe
        {
            get
            {
                return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), 
                @"Microsoft Silverlight\sllauncher.exe");
            }
        }
    private static void UninstallExisting(string xapUriToRemove)
        {
            string installArgs = "/uninstall" + " /origin:" + xapUriToRemove;
            ProcessStartInfo pstart = new ProcessStartInfo(silverlightExe, installArgs);
            Process p = new Process();
            pstart.UseShellExecute = false;
            p.StartInfo = pstart;
            p.Start();
            p.WaitForExit();
        }
    
