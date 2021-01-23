     public static void GenerateNewStylePDF(string domain, string url, string applicationPath)
        {
            var p = new Process();
            var startInfo = new ProcessStartInfo
                                {
                                    FileName = applicationPath + "\\bin\\wkhtmltopdf\\wkhtmltopdf.exe",
                                    Arguments = domain + url + " \"" + applicationPath + "export.pdf\"",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true
                                };
            p.StartInfo = startInfo;
            p.Start();
            var s = p.StandardOutput.ReadToEnd();
            var e = p.StandardError.ReadToEnd();
            p.WaitForExit();
        }
