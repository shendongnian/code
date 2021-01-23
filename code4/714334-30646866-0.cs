                if (!bwUpdateMembers.IsBusy)
                {
                    bwUpdateMembers.RunWorkerAsync();
                }
          
        }
        private string ExtractZip(FileInfo fi)
        {
            string extractTo = Path.Combine(fi.DirectoryName, Guid.NewGuid().ToString());
            using (ZipFile zip = ZipFile.Read(fi.FullName))
            {
                foreach (ZipEntry ze in zip)
                {
                    ze.Extract(extractTo, ExtractExistingFileAction.OverwriteSilently);
                }
            }
           
            return extractTo;
        }
        public FileInfo GetLatestFile(DirectoryInfo di)
        {
            FileInfo fi = di.GetFiles()
                                .OrderByDescending(d => d.CreationTime)
                                .FirstOrDefault();
            return fi;
        }
        private void bwUpdateMembers_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = "C:\\Users\\Ghost Wolf\\Desktop\\zip";
            DirectoryInfo di = new DirectoryInfo(path);
            if (di != null)
            {
                FileInfo fi = GetLatestFile(di);
                string folder = ExtractZip(fi);
                MessageBox.Show("Your'e Files Have Been Extracted", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            
        }
      
    }
