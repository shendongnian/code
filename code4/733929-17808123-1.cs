    public void UnzipMe(string path){
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/C unzip -n " + path + "\zipfile.zip -d " + path;
        process.StartInfo = startInfo;
        process.Start();
        //do some extra stuff here
    }
