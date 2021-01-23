    if (MFILE_OPTION_WAV_CHECKBOX.Checked == true)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    string[] files = System.IO.Directory.GetFiles(dir, "*.wav", SearchOption.TopDirectoryOnly);
                    foreach (string fileName in files)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        double fileSize = fi.Length;
                        totalFileSize += fileSize;
                    }
                };
                bw.RunWorkerCompleted += (s,e) =>
                {
                        //Update GUI
                 }
                bw.RunWorkerAsync();
            }
