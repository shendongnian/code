            public static bool GetVersionHack(string appPath,string targetPath,out long version)
            { 
               // <param name="appPath">Path to svnversion.exe</param>
               // <param name="path">Target path</param>
               // <param name="version">Result version</param>
                Process p = new Process();               
                
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = appPath;
                p.StartInfo.Arguments = targetPath + " -n";
                p.Start();
    
                //read svnversion.exe result
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
    
                output = output.Replace("M", "");
                output = output.Replace("S", "");
                output = output.Replace("P", "");
    
                //valid results
                //4123:4168     mixed revision working copy
                //4168M         modified working copy
                //4123S         switched working copy
                //4123P         partial working copy, from a sparse checkout
                //4123:4168MS   mixed revision, modified, switched working copy            
    
                return long.TryParse(output, out version);
            }
