    public void ExecuteCommandSync(object command, String PATH,bool redirect)
            {
                try
                {
                    //AllocConsole();
                    FreeConsole();
                    ProcessStartInfo pw = new ProcessStartInfo();
    
                    pw.FileName = @"cmd.exe";
    
                    pw.UseShellExecute = false;
                    pw.RedirectStandardInput = redirect;
                     
    
                    pr.StartInfo = pw;
    
                    pr.Start();
                    pr.StandardInput.WriteLine(@"cd "+ PATH);
                    pr.StandardInput.WriteLine(@""+command);
                     
    
                }
