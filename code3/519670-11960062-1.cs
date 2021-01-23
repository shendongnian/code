    var fileName = "C:\\path-to\\ping.exe";
    var arguments = txtHostname.Text;
    var processStartInfo = new ProcessStartInfo(fileName ,  arguments);
    processStartInfo.CreateNoWindow = true;
    processStartInfo.RedirectStandardOutput = true;
    processStartInfo.UseShellExecute = false;
    using (var process = Process.Start(processStartInfo)) {
        using (var streamReader = new StreamReader(process.StandardOutput.BaseStream, Encoding.UTF8)){
            while (streamReader.Peek() >= 0) 
            {
                listBox1.Items.Add(streamReader.ReadLine());
            }
        }
    }
