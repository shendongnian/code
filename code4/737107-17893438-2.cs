        private void MergeDirectories(string filePath1, string filePath2, string mergedName)
        {
            string workspace = Environment.CurrentDirectory;
            filePath1 = Path.Combine(workspace, filePath1);
            filePath2 = Path.Combine(workspace, filePath2);
            mergedName = Path.Combine(workspace, mergedName);
            if (File.Exists(mergedName))
            {
                File.Delete(mergedName);
            }
            DirectoryInfo zip1 = OpenAndExtract(filePath1);
            DirectoryInfo zip2 = OpenAndExtract(filePath2);
            string merged = Path.GetTempFileName();
            using (ZipFile z = new ZipFile())
            {
                z.AddDirectory(zip1.FullName);
                z.AddDirectory(zip2.FullName);
                z.Save(merged);
            }
            zip1.Delete(true);
            zip2.Delete(true);
            File.Move(merged, mergedName);
        }
        private DirectoryInfo OpenAndExtract(string path)
        {
            string tmpName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            string tmp = Path.Combine(Path.GetTempPath(), tmpName);
            FileInfo sourcePath = new FileInfo(path);
            DirectoryInfo tempPath = Directory.CreateDirectory(tmp);
            using (ZipFile zip = ZipFile.Read(sourcePath.FullName))
            {
                zip.ExtractAll(tempPath.FullName);
            }
            return tempPath;
        }
