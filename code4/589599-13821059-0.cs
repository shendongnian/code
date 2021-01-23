    public static byte[] Convert(string wkhtmltopdfPath, string switches, string html)
    {
        using (var tempFiles = new TempFileCollection())
        {
            var input = tempFiles.AddExtension("htm");
            var output = tempFiles.AddExtension("jpg");
            File.WriteAllText(input, html);
            switches += string.Format(" -f jpeg {0} {1}", input, output);
            var psi = new ProcessStartInfo(Path.Combine(wkhtmltopdfPath, "wkhtmltoimage.exe"))
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = switches
            };
            using (var process = Process.Start(psi))
            {
                process.WaitForExit((int)TimeSpan.FromSeconds(30).TotalMilliseconds);
            }
            return File.ReadAllBytes(output);
        }
    }
