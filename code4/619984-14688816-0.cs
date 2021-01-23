private void CreateZip(string largeDir, string splitIntoDir, double maxFolderSize)
        {
            int fileNumber = 1;
            List<String> files = new List<String>(Directory.GetFiles(largeDir, "*.pdf"));
            StringBuilder outputZip = new StringBuilder(splitIntoDir + Path.DirectorySeparatorChar + Path.GetFileName(largeDir) + "_" + fileNumber + @".zip");
            double currentOutputSize = 0;
            foreach (String file in files)
            {
                if (File.Exists(outputZip.ToString()))
                    currentOutputSize = new FileInfo(outputZip.ToString()).Length + new FileInfo(file).Length + new FileInfo(file.Replace(".pdf", ".idf")).Length;
                if (File.Exists(outputZip.ToString()) && (currentOutputSize >= maxFolderSize))
                {
                    fileNumber += 1;
                    outputZip.Clear();
                    outputZip.Append(splitIntoDir + Path.DirectorySeparatorChar + Path.GetFileName(largeDir) + "_" + fileNumber + @".zip");
                }
                using (ZipFile zip = new ZipFile(outputZip.ToString()))
                {
                    zip.AddFile(file, "");
                    if (File.Exists(file.Replace(".pdf", ".idf")))
                        zip.AddFile(file.Replace(".pdf", ".idf"), "");
                    zip.Save();
                }
            }
        }
