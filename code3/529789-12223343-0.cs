     1. Set a progress bar
     2. Set a Label on the progress bar to display number of files processed / number of file 
    to process
    
    
    try
        {
    
    
        lblUpdate.Visible = true;
        lblUpdate.Refresh();
        string[] filenames = Directory.GetFiles(sTargetFolderPath);
        //first set the max progressbar to your number of files
        yourProgressbar.Maximum = filenames.Length;
    
        // Zip up the files - From SharpZipLib Demo Code
        using (ZipOutputStream s = new ZipOutputStream(File.Create(lblSaveTo.Text + "\\" + sZipFileName + ".pld")))
        {
            s.SetLevel(9); // 0-9, 9 being the highest level of compression
        
            byte[] buffer = new byte[4096];
           
            foreach (string file in filenames)
            {
        
                ZipEntry entry = new ZipEntry(Path.GetFileName(file));
        
                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);
        
                using (FileStream fs = File.OpenRead(file))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                        s.Write(buffer, 0, sourceBytes);
        
                    } while (sourceBytes > 0);
                }
                //add 1 by file added and display number of files processed : 156/178 
                yourProgressbar.Value += 1;
                yourLabel.Text = yourProgressbar.Value.ToString() + "/" + filenames.Length ;
                 
            }
            s.Finish();
            s.Close();
        }
