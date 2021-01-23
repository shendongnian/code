    //possible seclog paths
    String seclogPath1 = @"\\\\" + target + "\\C$\\Program Files (x86)\\Symantec\\Symantec Endpoint Protection\\seclog.log";
    String seclogPath2 = @"\\\\" + target + "\\C$\\Program Files\\Symantec\\Symantec Endpoint Protection\\seclog.log";
    //if seclog exists
    if (File.Exists(seclogPath1))
    {
        //output.AppendText("file exists at " + seclogPath1);
        //var seclogContent = File.Open(seclogPath1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        Stream stream = File.Open(seclogPath1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //File.OpenRead(seclogPath1);
        StreamReader streamReader = new StreamReader(stream);
        string str = streamReader.ReadToEnd();
        output.AppendText(str);
        streamReader.Close();
        stream.Close();
                
    }
