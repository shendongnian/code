    var startInfo = new ProcessStartInfo("net", "view");
    startInfo.UseShellExecute = false;
    startInfo.CreateNoWindow = true;
    startInfo.RedirectStandardError = true;
    startInfo.RedirectStandardOutput = true;
    using (var process = Process.Start(startInfo))
    {
        string message;
        using (var reader = process.StandardOutput)
        {
            message = reader.ReadToEnd();
        }
        
        if (!string.IsNullOrEmpty(message))
        {
            MessageBox.Show(message);
        }
        else
        {
            using (var reader = process.StandardError)
            {
                MessageBox.Show(reader.ReadToEnd());
            }
        }
    }
