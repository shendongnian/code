        System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.StartInfo.FileName = //PHYSICAL path to ffmpeg (use \\ instead of \);
    proc.StartInfo.Arguments = "-i video.flv video.mp4
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.CreateNoWindow = true;
    proc.StartInfo.RedirectStandardOutput = false;
    proc.Start();
    proc.WaitForExit();
    proc.Close();
