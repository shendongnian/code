    ProcessStartInfo info = new ProcessStartInfo();
    info.Arguments = "/C ping 127.0.0.1";
    info.WindowStyle = ProcessWindowStyle.Hidden;
    info.CreateNoWindow = true;
    info.FileName = "cmd.exe";
    info.UseShellExecute = false;
    info.RedirectStandardOutput = true;
    using (Process process = Process.Start(info))
    {
        using (StreamReader reader = process.StandardOutput)
        {
            string result = reader.ReadToEnd();
            textBox1.Text += result;
        }
    }
