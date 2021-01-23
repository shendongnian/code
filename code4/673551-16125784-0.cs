     public static List<string> extentions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
    
            private void Open()
    {
        foreach (var selected in listBox4.Items)
        {
            string s = selected.ToString();
            if (listBox4Dict.ContainsKey(s))
            {
                if (extentions.Contains(Path.GetExtension(s).ToUpperInvariant()))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "rundll32.exe";
                    process.StartInfo.Arguments = @"C:\WINDOWS\System32\shimgvw.dll,ImageView_Fullscreen " +listBox4Dict[s];
                    process.Start();
                    process.WaitForExit();
                    while (!process.HasExited)
                        Thread.Sleep(500);
                }
                else
                {
                    Mediaplayer.URL = (listBox4Dict[s]);
                }
            }
        }
    };
