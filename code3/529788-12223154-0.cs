        try
    {
    lblUpdate.Visible = true;
    lblUpdate.Refresh();
    string[] filenames = Directory.GetFiles(sTargetFolderPath);
    // Zip up the files - From SharpZipLib Demo Code
    using (ZipOutputStream s = new ZipOutputStream(File.Create(lblSaveTo.Text + "\\" + sZipFileName + ".pld")))
    {
        s.SetLevel(9); // 0-9, 9 being the highest level of compression
        byte[] buffer = new byte[4096];
        int nPercentToAdvance = (100 / filenames.Length);
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
            this.prbProgressBar.Value += nPercentToAdvance;
        }
        s.Finish();
        s.Close();
    }
}
