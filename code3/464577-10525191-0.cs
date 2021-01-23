    private static void OpenBrowser(string url)
    {
            if (url != null)
            {
                Process process = new Process();
                process.StartInfo.FileName = "rundll32.exe";
                process.StartInfo.Arguments = "url.dll,FileProtocolHandler " + url;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
    }
