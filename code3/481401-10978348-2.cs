        private void ZipFolder(string folderName, string outputFile)
        { 
            string[] files = Directory.GetFiles(folderName);
            using (ZipOutputStream zos = new ZipOutputStream(File.Create(outputFile)))
            {
                zos.SetLevel(9); // 9 = highest compression
                byte[] buffer = new byte[4096];
                foreach (string file in files)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                    entry.DateTime = DateTime.Now;
                    zos.PutNextEntry(entry);
                    using (FileStream fs = File.OpenRead(file))
                    {
                       int byteRead;
                       do
                       {
                            byteRead = fs.Read(buffer, 0,buffer.Length);
                            zos.Write(buffer, 0, byteRead);
                       }
                       while (byteRead > 0);
                    }
                }
                zos.Finish();
                zos.Close();
            }
