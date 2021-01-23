    private void PrintPdf(string fileName)
    {
        var hkeyLocalMachine = Registry.LocalMachine.OpenSubKey(@"Software\Classes\Software\Adobe\Acrobat");
        if (hkeyLocalMachine != null)
        {
            var exe = hkeyLocalMachine.OpenSubKey("Exe");
            if (exe != null)
            {
                var acrobatPath = exe.GetValue(null).ToString();
                if (!string.IsNullOrEmpty(acrobatPath))
                {
                    var process = new Process
                    {
                        StartInfo =
                        {
                            UseShellExecute = false,
                            FileName = acrobatPath,
                            Arguments = string.Format(CultureInfo.CurrentCulture, "/T {0}", fileName)
                        }
                    };
                    process.Start();
                }
            }
        }
    }
