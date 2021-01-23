    // create the dxdiag.bat file 
    using (StreamWriter sw = new StreamWriter("dxdiag.bat"))
    {
       sw.WriteLine(".........");
       // ......
    }
    
    Process proc = new Process();
    proc.EnableRaisingEvents = true;
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.FileName = "dxdiag.bat";
    proc.StartInfo.CreateNoWindow = true;
    proc.Start();
    proc.WaitForExit();
    proc.Close();
    
    //delete the file 
    File.Delete("dxdiag.bat");
