    foreach (string pdf in ListFilePath)
                        {
                            string filename = System.IO.Path.GetFileName(pdf);
                            string fullPath = (@"U:\Define\Full\Path" + filename);
                            Print(fullPath, 'PrinterNameHere');
                        }
    public static bool Print(string file, string printer)
            {
                try
                {
                    Process.Start(Registry.LocalMachine.OpenSubKey(
                            @"SOFTWARE\Microsoft\Windows\CurrentVersion" +
                            @"\App Paths\AcroRd32.exe").GetValue("").ToString(),
                            string.Format("/h /t \"{0}\" \"{1}\"", file, printer));
                    return true;
                }
                catch { }
                return false;
            }
