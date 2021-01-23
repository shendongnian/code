        output = StartProcessing("MySelfExtractExeFile.exe", " /auto " + sOutputFilePath);
        private string StartProcessing(string sProcessingFile, string Arguments)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = sProcessingFile;// "cmd.exe";
                p.StartInfo.Arguments = Arguments;// " /auto " + sOutputFilePath;
                            
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                //make the window Hidden 
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return output;
            }
            catch (Exception ex)
            {
                
                return ex            
            }
        }
